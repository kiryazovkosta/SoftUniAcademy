-- 6.Find Email Address of Each Employee

USE SoftUni
GO

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address] FROM Employees