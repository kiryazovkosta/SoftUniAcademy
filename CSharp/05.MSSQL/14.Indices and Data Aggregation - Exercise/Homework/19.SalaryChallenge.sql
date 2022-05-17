-- 19. **Salary Challenge

SELECT e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE Salary > (
	SELECT AVG(ee.Salary)
	FROM Employees AS ee
	WHERE ee.DepartmentID = e.DepartmentID
	GROUP BY ee.DepartmentID
)
ORDER BY e.DepartmentID