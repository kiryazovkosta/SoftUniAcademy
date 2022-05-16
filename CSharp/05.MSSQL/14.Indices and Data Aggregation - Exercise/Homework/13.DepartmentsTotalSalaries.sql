-- 13. Departments Total Salaries

SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID