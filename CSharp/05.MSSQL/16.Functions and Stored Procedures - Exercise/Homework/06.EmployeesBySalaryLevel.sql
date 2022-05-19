-- 6.	Employees by Salary Level
-- Write a stored procedure usp_EmployeesBySalaryLevel that receive as parameter level of salary (low, average or high) 
-- and print the names of all employees that have given level of salary. You should use the function - "dbo.ufn_GetSalaryLevel(@Salary) ", 
-- which was part of the previous task, inside your "CREATE PROCEDURE …" query.

CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel(@Level NVARCHAR(10))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level

EXEC usp_EmployeesBySalaryLevel 'High'