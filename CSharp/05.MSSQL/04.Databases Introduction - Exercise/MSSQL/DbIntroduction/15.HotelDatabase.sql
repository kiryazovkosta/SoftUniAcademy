-- Problem 15.Hotel Database

--Set most appropriate data types for each column. Set primary key to each table. 
--Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. 
--Consider which fields are always required and which are optional. 
--Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE DATABASE Hotel
GO

USE Hotel
GO

CREATE TABLE Employees 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(80) NOT NULL, 
	LastName NVARCHAR(80) NOT NULL, 
	Title NVARCHAR(32), 
	Notes NVARCHAR(512)
)
INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES
	('Ivan', 'Popov', 'Mr.', NULL),
	('Petar', 'Ivanov', NULL, NULL),
	('Georgi', 'Georgiev', NULL, 'Notes for Georgi Georgiev')

CREATE TABLE Customers 
(
	AccountNumber INT NOT NULL PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	PhoneNumber NVARCHAR(16), 
	EmergencyName NVARCHAR(50), 
	EmergencyNumber NVARCHAR(16), 
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers(FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber,Notes)
VALUES
	('Anton','Antonov','+555-1324','Vanko','+359811123456',NULL),
	('Anton','Antonov','+555-1324','Vanko','+359811123456',NULL),
	('Anton','Antonov','+555-1324','Vanko','+359811123456',NULL)

CREATE TABLE RoomStatus 
(
	RoomStatus NVARCHAR(32) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX),
	CONSTRAINT UC_RoomStatus UNIQUE(RoomStatus)
)
INSERT INTO RoomStatus (RoomStatus)
VALUES
	('Reserved'), ('Occupied'), ('Available')

CREATE TABLE RoomTypes 
(
	RoomType NVARCHAR(32) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX),
	CONSTRAINT UC_RoomType UNIQUE(RoomType)
)
INSERT INTO RoomTypes (RoomType)
VALUES
	('Single'), ('Double'), ('Suite')

CREATE TABLE BedTypes 
(
	BedType NVARCHAR(32) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX),
	CONSTRAINT UC_BedType UNIQUE(BedType)
)
INSERT INTO BedTypes (BedType)
VALUES
	('Single'), ('Twin'), ('Double')

CREATE TABLE Rooms 
(
	RoomNumber INT NOT NULL PRIMARY KEY IDENTITY, 
	RoomType NVARCHAR(32) NOT NULL, 
	BedType NVARCHAR(32) NOT NULL, 
	Rate DECIMAL(5, 1), 
	RoomStatus NVARCHAR(32) NOT NULL, 
	Notes NVARCHAR(MAX)
	CONSTRAINT FK_Room_RoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_Room_BedType FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
	CONSTRAINT FK_Room_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus),
)
INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
	('Single', 'Single', 7.0, 'Reserved', NULL),
	('Double', 'Twin', 8.2, 'Occupied', NULL),
	('Suite', 'Double', 9.4, 'Available', 'Our best room.Only for VIP clients')

CREATE TABLE Payments 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATETIME, 
	LastDateOccupied DATETIME, 
	TotalDays INT, 
	AmountCharged DECIMAL(10,2), 
	TaxRate DECIMAL(10,2), 
	TaxAmount DECIMAL(10,2), 
	PaymentTotal DECIMAL(10,2), 
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_Payment_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Payment_Customer FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
)
INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
	(1, '2022-01-22', 1, '2022-01-21', '2022-01-22', 1, 100.00, 0.20, 20.00, 120.00),
	(1, '2022-01-22', 2, '2022-01-20', '2022-01-22', 2, 200.00, 0.20, 40.00, 240.00),
	(1, '2022-01-22', 3, '2022-01-19', '2022-01-22', 3, 300.00, 0.20, 60.00, 360.00)

CREATE TABLE Occupancies 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME NOT NULL, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT NOT NULL, 
	RateApplied DECIMAL(5,2), 
	PhoneCharge BIT, 
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_Occupancy_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_Occupancy_Customer FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
	CONSTRAINT FK_Occupancy_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
)
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
	(1, '2022-01-22', 1, 1, 7.0, 0),
	(2, '2022-01-22', 2, 2, 10.0, 0),
	(3, '2022-01-22', 3, 3, 9.5, 1)

