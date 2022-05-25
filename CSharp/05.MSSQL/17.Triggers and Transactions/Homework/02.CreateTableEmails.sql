-- 2. Create Table Emails
USE [Bank]
GO

CREATE TABLE NotificationEmails
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Recipient INT
	,[Subject] VARCHAR(64) NOT NULL
	, Body VARCHAR(256) NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_CreateNotificationEmailWhenLogIsCreated ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @oldSum INT = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @newSum INT = (SELECT TOP(1) NewSum FROM inserted)

	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	VALUES 
	(
		@accountId
		,'Balance change for account: ' + CAST(@accountId AS VARCHAR(20))
		,'On ' + CONVERT(VARCHAR(30), GETDATE(), 100) + ' your balance was changed from ' 
			+ CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20)) + '.'
	)
GO

