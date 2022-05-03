-- 04. Find All Employees Except Engineers

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'