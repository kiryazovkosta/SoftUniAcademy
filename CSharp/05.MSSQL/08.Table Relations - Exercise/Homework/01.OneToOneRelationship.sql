-- Problem 1.	One-To-One Relationship

CREATE TABLE Passports
(
	PassportID INT NOT NULL,
	PassportNumber NVARCHAR(16) NOT NULL
	CONSTRAINT PK_Passport PRIMARY KEY(PassportID)
)

CREATE TABLE Persons (
	PersonID INT NOT NULL IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(8,2) NULL,
	PassportID INT NOT NULL,
	CONSTRAINT PK_Person PRIMARY KEY(PersonID),
	CONSTRAINT AK_PassportID UNIQUE(PassportID),
	CONSTRAINT FK_Person_Passport FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES 
	(101,'N34FG21B'), 
	(102, 'K65LO4R7'), 
	(103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES 
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)