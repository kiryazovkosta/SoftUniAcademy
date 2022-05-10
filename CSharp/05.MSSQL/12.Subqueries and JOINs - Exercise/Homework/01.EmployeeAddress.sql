-- 1.Employee Address

SELECT TOP(5)
	e.EmployeeID, 
	e.JobTitle, 
	e.AddressID, 
	a.AddressText
FROM Employees e
INNER JOIN Addresses a ON a.AddressID = e.AddressID
ORDER BY e.AddressID ASC