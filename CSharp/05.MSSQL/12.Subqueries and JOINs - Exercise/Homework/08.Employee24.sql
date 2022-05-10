-- 08. Employee 24

SELECT e.EmployeeID, e.FirstName, IIF(DATEPART(YEAR, p.StartDate) < 2005, p.Name, NULL) AS ProjectName
FROM Employees e
INNER JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24