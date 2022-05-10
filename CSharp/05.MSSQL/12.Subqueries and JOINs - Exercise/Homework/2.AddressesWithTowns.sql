-- 2.	Addresses with Towns

SELECT TOP(50)
	FirstName,
	LastName,
	t.Name As City,
	AddressText
FROM Employees e
LEFT JOIN Addresses a ON a.AddressID = e.AddressID
LEFT JOIN Towns t ON t.TownID = a.TownID
ORDER BY FirstName ASC, LastName