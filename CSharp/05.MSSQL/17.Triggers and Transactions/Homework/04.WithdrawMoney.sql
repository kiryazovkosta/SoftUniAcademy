-- 4.	Withdraw Money

CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN
	BEGIN TRANSACTION

	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account id!', 16, 1)
		RETURN
	END

	IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Negative number.', 16, 1)
		RETURN
	END

	DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE Id = @accountId)
	IF (@balance IS NULL OR @balance < @moneyAmount)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid balance.', 16, 1)
		RETURN
	END

	UPDATE Accounts SET Balance -= @moneyAmount WHERE Id = @accountId
	COMMIT
END

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts WHERE Id = 5