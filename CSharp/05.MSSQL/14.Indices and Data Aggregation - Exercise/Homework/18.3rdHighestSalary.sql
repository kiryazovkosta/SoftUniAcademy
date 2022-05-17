-- 18. *3rd Highest Salary
SELECT DepartmentID, Salary
FROM
(SELECT DepartmentID, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) Ranked
FROM Employees
GROUP BY DepartmentID, Salary) AS Result
WHERE Ranked = 3