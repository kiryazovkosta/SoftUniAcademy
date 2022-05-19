-- 12.	Calculating Interest
-- Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem 
-- to give an interest to a person's account for 5 years, along with information about his/her account id, first name, last name and current balance 
-- as it is shown in the example below. It should take the AccountId and the interest rate as parameters. 
-- Again you are provided with “dbo.ufn_CalculateFutureValue” function which was part of the previous task.

CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
BEGIN
	SELECT 
		ah.Id AS [Account Id]
		,ah.FirstName AS [First Name]
		,ah.LastName AS [Last Name]
		,a.Balance AS [Current Balance]
		,dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.Id = ah.Id 
	WHERE a.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1