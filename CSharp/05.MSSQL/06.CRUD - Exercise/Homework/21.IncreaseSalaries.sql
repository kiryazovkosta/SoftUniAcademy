-- 21. Increase Salaries
-- Write a SQL query to increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. 
-- Then select Salaries column from the Employees table. After that exercise restore your database to revert those changes.

USE SoftUni
GO

SELECT Salary FROM Employees

UPDATE Employees
SET Salary = Salary + (Salary * 0.12)
WHERE DepartmentID IN (
	SELECT [DepartmentID] 
	FROM Departments 
	WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
)

SELECT Salary FROM Employees