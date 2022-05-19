-- 2.	Employees with Salary Above Number
-- Create stored procedure usp_GetEmployeesSalaryAboveNumber that accept a number (of type DECIMAL(18,4)) as parameter 
-- and returns all employees’ first and last names whose salary is above or equal to the given number.

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 40000