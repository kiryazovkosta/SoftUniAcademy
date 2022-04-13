-- Problem 16.Create SoftUni Database

--Now create bigger database called SoftUni. You will use same database in the future tasks. It should hold information about
--•	Towns (Id, Name)
--•	Addresses (Id, AddressText, TownId)
--•	Departments (Id, Name)
--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
--Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). 
--Make sure you use appropriate data types for each column. 
--Add primary and foreign keys as constraints for each table. 
--Use only SQL queries. Consider which fields are always required and which are optional.

CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(64) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT NOT nULL PRIMARY KEY IDENTITY(1,1), 
	AddressText NVARCHAR(256) NOT NULL, 
	TownId INT NOT NULL
)
ALTER TABLE Addresses ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

CREATE TABLE Departments 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Name NVARCHAR(64) NOT NULL
)

CREATE TABLE Employees 
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	JobTitle NVARCHAR(64) NOT NULL, 
	DepartmentId INT NOT NULL, 
	HireDate DATETIME NOT NULL, 
	Salary DECIMAL(12,2) NOT NULL, 
	AddressId INT,
)
ALTER TABLE Employees ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
ALTER TABLE Employees ADD FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

