-- Problem 14.	Car Rental Database

--Using SQL queries create CarRental database with the following entities:
--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--Set most appropriate data types for each column. 
--Set primary key to each table. 
--Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. 
--Consider which fields are always required 

CREATE DATABASE CarRental
GO

USE CarRental
GO

CREATE TABLE Categories 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	CategoryName NVARCHAR(256) NOT NULL, 
	DailyRate DECIMAL(5,2) NOT NULL, 
	WeeklyRate DECIMAL(5,2) NOT NULL, 
	MonthlyRate DECIMAL(5,2),
	WeekendRate DECIMAL(5,2),
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Category1', 9.23, 8.33, 9.02, 8.99),
('Category2', 7.44, 7.64, NULL, 8.51),
('Category3', 6.84, 8.12, NULL, NULL)

CREATE TABLE Cars 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	PlateNumber NVARCHAR(16) NOT NULL, 
	Manufacturer NVARCHAR(32) NOT NULL, 
	Model NVARCHAR(32) NOT NULL, 
	CarYear SMALLINT NOT NULL, 
	CategoryId INT NOT NULL, 
	Doors TINYINT, 
	Picture NVARCHAR(256), 
	Condition NVARCHAR(50), 
	Available BIT NOT NULL
)

ALTER TABLE Cars ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('A1234BC', 'Toyota', 'Corolla', 2014, 2, 4, NULL, 'Very Good', 1),
('B9876DE', 'Peugeoth', '206+', 2006, 1, 2, 'path_to_image', 'Good', 1),
('S5061SS', 'Opel', 'Astra', 1997, 3, 4, NULL, 'Poor', 0)

CREATE TABLE Employees 
(
	Id INT NOT NULL PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(32), 
	Notes NVARCHAR(32)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES 
(1, 'First1', 'Last2', 'Prof', 'Some notes for Employee1'),
(2, 'First2', 'Last2', 'Prof', NULL),
(3, 'First3', 'Last3', 'Prof', NULL)

CREATE TABLE Customers 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	DriverLicenceNumber NVARCHAR(32) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
	City NVARCHAR(32) NOT NULL, 
	ZIPCode NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
('DriverLicenceNumber1', 'FullName', 'Address', 'City', 'ZIPCode', 'Notes'),
('DriverLicenceNumber2', 'FullName', 'Address', 'City', 'ZIPCode', NULL),
('DriverLicenceNumber3', 'FullName', 'Address', 'City', 'ZIPCode', 'Notes')

CREATE TABLE RentalOrders 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT , 
	TankLevel TINYINT, 
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATETIME NOT NULL, 
	EndDate DATETIME NOT NULL, 
	TotalDays INT, 
	RateApplied NVARCHAR(16), 
	TaxRate DECIMAL(5,2), 
	OrderStatus INT NOT NULL, 
	Notes NVARCHAR(512)
)

ALTER TABLE RentalOrders ADD FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
ALTER TABLE RentalOrders ADD FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
ALTER TABLE RentalOrders ADD FOREIGN KEY (CarId) REFERENCES Cars(Id)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES 
(1, 1, 1, 55, NULL, NULL, NULL, '2022-04-01', '2022-04-05', 5, 'SOLO', 2.3, 1, NULL),
(2, 2, 2, 48, NULL, NULL, NULL, '2022-04-01', '2022-04-05', 5, 'SOLO', 2.3, 1, NULL),
(3, 3, 3, 220, NULL, NULL, NULL, '2022-04-01', '2022-04-05', 5, 'SOLO', 2.3, 1, NULL)
