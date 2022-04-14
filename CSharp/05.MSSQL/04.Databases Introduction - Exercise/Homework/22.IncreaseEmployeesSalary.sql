-- Problem 22. Increase Employees Salary
USE SoftUni
GO

UPDATE Employees
SET Salary = Salary + (Salary * 0.1)

SELECT Salary FROM Employees