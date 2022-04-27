-- Problem 2.	One-To-Many Relationship
CREATE TABLE Manufacturers
(
ManufacturerID INT NOT NULL PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
EstablishedOn DATETIME NOT NULL
)

INSERT INTO Manufacturers([Name],[EstablishedOn])
VALUES
	('BMW', '1916-03-07'), 
	('Tesla', '2003-01-01'), 
	('Lada', '1966-05-01')

CREATE TABLE Models
(
	ModelID INT NOT NULL IDENTITY(101, 1),
	[Name] NVARCHAR(32) NOT NULL,
	ManufacturerID INT NOT NULL,
	CONSTRAINT PK_Model PRIMARY KEY(ModelID),
	CONSTRAINT FK_Model_Manufacture FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models([Name],ManufacturerID)
VALUES
	('X1',	1),
	('i6',	1),
	('Model S',	2),
	('Model X',	2),
	('Model 3',	2),
	('Nova',	3)