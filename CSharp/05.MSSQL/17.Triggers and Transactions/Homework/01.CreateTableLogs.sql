-- 1.Create Table Logs

CREATE TABLE Logs
(
	LogId INT NOT NULL PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
	DECLARE @newSum MONEY = (SELECT Balance FROM inserted)
	DECLARE @oldSum MONEY = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs(AccountId, OldSum, NewSum) 
	VALUES (@accountId, @oldSum, @newSum)
GO