-- 10. Employee Summary

SELECT TOP(50) 
	e.EmployeeID, 
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
JOIN Employees m ON m.EmployeeID = e.ManagerID
ORDER BY e.EmployeeID ASC