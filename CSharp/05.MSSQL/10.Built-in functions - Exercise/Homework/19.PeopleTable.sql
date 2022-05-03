-- Problem 19.	 People Table
CREATE TABLE People (
	Id INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People(Id, Name, Birthdate)
VALUES
	(1, 'Victor', '2000-12-07'),
	(2, 'Steven', '1992-09-10'),
	(3, 'Stephen', '1910-09-19'),
	(4, 'John', '2010-01-06')

SELECT Name, 
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People