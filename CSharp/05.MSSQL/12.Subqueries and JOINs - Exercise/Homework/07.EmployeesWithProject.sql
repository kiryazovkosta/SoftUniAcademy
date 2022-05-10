-- 7.	Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName
FROM Employees e
INNER JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND EndDate Is NULL
ORDER BY e.EmployeeID ASC