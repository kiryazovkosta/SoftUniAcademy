-- 11. Min Average Salary

SELECT TOP(1) AVG(e.Salary)
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID
ORDER BY AVG(e.Salary) ASC