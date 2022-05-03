-- 02. Find Names of All Employees by Last Name

SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('ei', LastName, 1) > 0