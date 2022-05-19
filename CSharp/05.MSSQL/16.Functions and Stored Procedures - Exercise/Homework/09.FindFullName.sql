-- 9.	Find Full Name
-- You are given a database schema with tables AccountHolders(Id (PK), FirstName, LastName, SSN) and Accounts(Id (PK), AccountHolderId (FK), Balance).  
-- Write a stored procedure usp_GetHoldersFullName that selects the full names of all people. 

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' '  + LastName AS FullName
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName
