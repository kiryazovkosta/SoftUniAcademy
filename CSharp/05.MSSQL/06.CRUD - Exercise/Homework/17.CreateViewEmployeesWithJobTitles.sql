-- 17. Create View Employees with Job Titles

USE SoftUni
GO

CREATE VIEW V_EmployeeNameJobTitle
AS
	SELECT 
		FirstName + ' ' + IIF(MiddleName IS NOT NULL, MiddleName, '') + ' ' + LastName AS [Full Name],
		JobTitle
	FROM Employees
GO

SELECT * FROM V_EmployeeNameJobTitle