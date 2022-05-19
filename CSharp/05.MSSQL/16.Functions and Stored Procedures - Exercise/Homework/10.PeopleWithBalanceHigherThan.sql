-- 10.	People with Balance Higher Than
-- Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan 
-- that accepts a number as a parameter and returns all people who have more money in total of all their accounts than the supplied number. 
-- Order them by first name, then by last name

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@balance MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders ah
	JOIN Accounts a ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @balance
	ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 500000