CREATE DATABASE Airport
GO

USE Airport
GO

-- 1. Database design
CREATE TABLE Passengers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FullName VARCHAR(100) NOT NULL UNIQUE
	,Email VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Pilots
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName VARCHAR(30) NOT NULL UNIQUE
	,LastName VARCHAR(30) NOT NULL UNIQUE
	,Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62)
	,Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0) 
)

CREATE TABLE AircraftTypes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,TypeName VARCHAR(30) NOT NULL UNIQUE
)

CREATE TABLE Aircraft
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Manufacturer VARCHAR(25) NOT NULL
	,Model VARCHAR(30) NOT NULL
	,Year INT NOT NULL
	,FlightHours INT
	,Condition CHAR NOT NULL
	,TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id)
	,PilotId INT NOT NULL REFERENCES Pilots(Id)
	,PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,AirportName VARCHAR(70) NOT NULL UNIQUE
	,Country VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE FlightDestinations
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,AirportId INT NOT NULL REFERENCES Airports(Id)
	,[Start] DATETIME NOT NULL
	,AircraftId INT NOT NULL REFERENCES Aircraft(Id)
	,PassengerId INT NOT NULL REFERENCES Passengers(Id)
	,TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT(15)
)

-- 2. Insert
INSERT INTO Passengers (FullName, Email)
SELECT FirstName + ' ' + LastName AS FullName, FirstName+LastName+'@gmail.com' AS Email
FROM Pilots
WHERE Id BETWEEN 5 AND 15

-- 3. Update
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B')
	AND (FlightHours IS NULL OR FlightHours <= 100)
	AND Year >= 2013

-- 4. Delete
DELETE FROM Passengers
WHERE LEN(FullName) <= 10

-- 5. Aircraft
SELECT 
	Manufacturer
	,Model
	,FlightHours
	,Condition
FROM Aircraft
ORDER BY FlightHours DESC

-- 6. Pilots and Aircraft
SELECT 
	p.FirstName
	,p.LastName
	,a.Manufacturer
	,a.Model
	,a.FlightHours
FROM Pilots p
JOIN PilotsAircraft pa ON pa.PilotId = p.Id
JOIN Aircraft a ON pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL AND a.FlightHours <= 304
ORDER BY a.FlightHours DESC, p.FirstName ASC

-- 7. Top 20 Flight Destinations
SELECT TOP(20) 
	fd.Id
	,fd.[Start]
	,p.FullName
	,a.AirportName
	, fd.TicketPrice
FROM FlightDestinations fd
JOIN Airports a ON a.Id = fd.AirportId
JOIN Passengers p ON p.Id = fd.PassengerId
WHERE DATEPART(DAY, [Start]) % 2 = 0
ORDER BY TicketPrice DESC

-- 8. Number of Flights for Each Aircraft
SELECT 
	a.Id, 
	a.Manufacturer, 
	a.FlightHours AS FlightHours, 
	COUNT(*) AS FlightDestinationsCount, 
	ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft a
JOIN FlightDestinations fd ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(*) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id ASC

-- 9. Regular Passengers
SELECT 
	p.FullName,
	COUNT(*) CountOfAircraft,
	SUM(fd.TicketPrice) TotalPayed
FROM Passengers p
JOIN FlightDestinations fd ON p.Id = fd.PassengerId
JOIN Aircraft a ON a.Id = fd.AircraftId
GROUP BY p.FullName
HAVING COUNT(*) > 1 AND CHARINDEX('a', p.FullName) = 2 
ORDER BY p.FullName ASC

-- 10.	Full Info for Flight Destinations
SELECT 
	a.AirportName
	,fd.Start
	,fd.TicketPrice
	,p.FullName
	,aa.Manufacturer
	,aa.Model
	--,CAST(DATEPART(HOUR, fd.Start) AS VARCHAR(2)) + CAST(DATEPART(MINUTE, fd.Start) AS VARCHAR(2))
	--,DATEPART(HOUR, fd.Start) * 100 + DATEPART(MINUTE, fd.Start)
FROM FlightDestinations fd
JOIN Airports a ON fd.AirportId = a.Id
JOIN Passengers p ON fd.PassengerId = p.Id
JOIN Aircraft aa ON fd.AircraftId = aa.Id
WHERE DATEPART(HOUR, fd.Start) * 100 + DATEPART(MINUTE, fd.Start) BETWEEN 600 AND 2000
	AND fd.TicketPrice > 2500
ORDER BY aa.Model ASC

-- 11.	Find all Destinations by Email Address
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(*)
	FROM FlightDestinations fd
	JOIN Passengers p ON p.Id = fd.PassengerId
	WHERE p.Email = @email)
	RETURN @count;
END
GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

-- 12.	Full Info for Airports
GO
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	
	SELECT 
		a.AirportName
		,p.FullName
		,CASE 
			WHEN fd.TicketPrice < 400 THEN 'Low'
			WHEN fd.TicketPrice > 1501 THEN 'High'
			ELSE 'Medium'
		END AS A
		,aa.Manufacturer
		,aa.Condition
		,at.TypeName
	FROM Airports a
	JOIN FlightDestinations fd ON fd.AirportId = a.Id
	JOIN Passengers p ON fd.PassengerId = p.Id
	JOIN Aircraft aa ON fd.AircraftId = aa.Id
	JOIN AircraftTypes at ON aa.TypeId = at.Id
	WHERE a.AirportName = @airportName
	ORDER BY aa.Manufacturer, p.FullName

END
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'