-- 6.	Employees Hired After

SELECT FirstName, LastName, HireDate, Name AS DeptName
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC