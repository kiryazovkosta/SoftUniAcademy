-- 5.	Money Transfer

CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
	COMMIT
END

EXEC usp_TransferMoney 1, 2, 100