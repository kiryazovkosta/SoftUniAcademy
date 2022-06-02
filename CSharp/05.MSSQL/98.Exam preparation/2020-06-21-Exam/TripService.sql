CREATE DATABASE TripService
GO

USE TripService
GO

-- 1. Database design
CREATE TABLE Cities
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(20) NOT NULL
	,CountryCode CHAR(2) NOT NULL
)
CREATE TABLE Hotels
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name]	NVARCHAR(30) NOT NULL
	,CityId INT NOT NULL REFERENCES Cities(Id)
	,EmployeeCount INT NOT NULL
	,BaseRate DECIMAL(15,2)
)
CREATE TABLE Rooms
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Price DECIMAL(15, 2) NOT NULL
	,[Type] NVARCHAR(20) NOT NULL
	,Beds INT NOT NULL
	,HotelId INT NOT NULL REFERENCES Hotels(Id) 
)
CREATE TABLE Trips
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,RoomId INT NOT NULL REFERENCES Rooms(Id)
	,BookDate DATE NOT NULL 
	,ArrivalDate DATE NOT NULL
	,ReturnDate DATE NOT NULL
	,CancelDate DATE NULL
)
ALTER TABLE Trips ADD CONSTRAINT chk_BookDateArrivalDate CHECK(BookDate < ArrivalDate)
ALTER TABLE Trips ADD CONSTRAINT chk_ArrivalDateReturnDate CHECK(ArrivalDate < ReturnDate)

CREATE TABLE Accounts
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(20)
	,LastName NVARCHAR(50) NOT NULL
	,CityId INT NOT NULL REFERENCES Cities(Id)
	,BirthDate DATE NOT NULL
	,Email VARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL REFERENCES Accounts(Id)
	,TripId INT NOT NULL REFERENCES Trips(Id)
	,PRIMARY KEY(AccountId,TripId)
	,Luggage INT NOT NULL CHECK(Luggage >= 0)
)

-- 2. Insert
INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email)
VALUES
	('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com')
	,('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com')
	,('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg')
	,('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
	(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02')
	,(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29')
	,(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL)
	,(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10')
	,(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

-- 3. Update
UPDATE Rooms
   SET Price += Price * 0.14
 WHERE HotelId IN (5, 7 ,9)

-- 4. Delete
DELETE FROM AccountsTrips WHERE AccountId = 47

-- 5. EEE-Mails
SELECT 
	a.FirstName
	,a.LastName
	,FORMAT(a.BirthDate, 'MM-dd-yyyy') as Hometown
	,c.[Name]
	,a.Email
FROM Accounts a
JOIN Cities c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.[Name] ASC

-- 6. City Statistics
SELECT 
	c.[Name] AS City, 
	COUNT(*) AS Hotels
FROM Hotels h
JOIN Cities c ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC, City ASC

-- 7. Longest and Shortest Trips
SELECT 
	a.Id AS AccountId
	,a.FirstName + ' ' + a.LastName AS FullName
	,MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip
	,MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts a
JOIN AccountsTrips [at] ON [at].AccountId = a.Id
JOIN Trips t ON t.Id = [at].TripId
WHERE [a].MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC

-- 8. Metropolis
SELECT TOP(10) 
	c.Id, 
	c.Name, 
	c.CountryCode,
	COUNT(*) AS Accounts
FROM Cities c
JOIN Accounts a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

-- 9. Romantic Getaways
SELECT 
	a.Id	
	,a.Email	
	,c.Name AS City
	, COUNT(*) AS Trips
FROM AccountsTrips at
JOIN Accounts a ON a.Id = at.AccountId
JOIN Cities c ON c.Id = a.CityId
JOIN Trips t ON t.Id = at.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id ASC 

-- 10. GDPR Violation
SELECT 
	t.Id,
	a.FirstName + IIF(a.MiddleName IS NULL, ' ', ' ' + a.MiddleName + ' ') + a.LastName AS [Full Name],
	c.Name,
	cc.Name,
	IIF(t.CancelDate IS NULL, CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR(4)) + ' days'  , 'Canceled')
FROM Trips t
JOIN AccountsTrips at ON at.TripId = t.Id
JOIN Accounts a ON a.Id = at.AccountId
JOIN Cities c ON c.Id = a.CityId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities cc ON cc.Id = h.CityId
ORDER BY [Full Name], t.Id
GO

-- 11. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (
			SELECT TOP(1) 
				'Room ' + CAST(r.Id AS VARCHAR(50)) +': ' + CAST(r.Type AS VARCHAR(50)) 
				+ ' (' + CAST(r.Beds AS VARCHAR(50)) +' beds) - $' 
				+ CAST((h.BaseRate + r.Price) * @People AS VARCHAR(50))
			FROM Rooms r
			JOIN Hotels h ON r.HotelId = h.Id
			WHERE HotelId = @HotelId 
				AND Beds >= @People 
				AND NOT EXISTS(
					SELECT * 
					FROM Trips 
					WHERE RoomId = r.Id 
						AND CancelDate IS NULL
						AND @Date BETWEEN ArrivalDate AND ReturnDate
					)
			ORDER BY (h.BaseRate + r.Price) * @People DESC)

	If (@RoomInfo IS NULL)
		RETURN 'No rooms available'
	RETURN @RoomInfo
END
GO

-- 12. Switch Room
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.HotelId 
								FROM Trips t
								JOIN Rooms r ON t.RoomId = r.Id
								WHERE t.Id = @TripId)
	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	IF (@TripHotelId <> @TargetRoomHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1)
		RETURN
	END

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	IF (@TripAccounts > @TargetRoomBeds)
	BEGIN
		RAISERROR('Not enough beds in target room!', 16, 1)
		RETURN
	END

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8

