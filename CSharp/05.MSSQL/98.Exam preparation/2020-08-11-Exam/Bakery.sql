CREATE DATABASE Bakery
GO

USE Bakery
GO

-- 1.	Database design
CREATE TABLE Countries
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,	
	LastName NVARCHAR(25) NOT NULL,	
	Gender CHAR(1) NOT NULL CHECK(Gender IN ('M', 'F')),
	Age	INT NOT NULL,	
	PhoneNumber	CHAR(10),
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL UNIQUE,
	Description NVARCHAR(250),	
	Recipe NVARCHAR(MAX) NOT NULL,	
	Price DECIMAL(15, 2) NOT NULL CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),	
	Rate DECIMAL(15, 2) CHECK(Rate BETWEEN 0.00 AND 10.00),
	ProductId INT NOT NULL REFERENCES Products(Id),
	CustomerId INT NOT NULL REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL UNIQUE,
	AddressText	NVARCHAR(30) NOT NULL,	
	Summary	NVARCHAR(200) NOT NULL,
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,	
	Description NVARCHAR(200) NOT NULL,	
	OriginCountryId	INT NOT NULL REFERENCES Countries(Id),
	DistributorId INT NOT NULL REFERENCES Distributors(Id),
)

CREATE TABLE ProductsIngredients
(
	ProductId INT NOT NULL REFERENCES Products(Id),
	IngredientId INT NOT NULL REFERENCES Ingredients(Id),
	PRIMARY KEY(ProductId, IngredientId)
)

-- 2.	Insert
INSERT INTO Distributors (Name, CountryId, AddressText, Summary)
VALUES
	('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
	('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
	('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
	('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
	('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
	('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
	('Kendra', 'Loud', 22, 'F', '0063631526',	11),
	('Lourdes', 'Bauswell', 50, 'M', '0139037043',	8),
	('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
	('Tom', 'Loeza', 31, 'M', '0144876096',	23),
	('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
	('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
	('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

-- 3.	Update
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

-- 4.	Delete
DELETE
FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

-- 5.	Products by Price
SELECT Name, Price, Description
FROM Products
ORDER BY Price DESC, Name ASC

-- 6.	Negative Feedback
SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
FROM Feedbacks f 
JOIN Customers c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate ASC

-- 7.	Customers without Feedback
SELECT 
	CONCAT(FirstName, ' ', LastName) AS CustomerName
	,c.PhoneNumber
	,c.Gender
FROM Customers c
LEFT JOIN Feedbacks f ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id ASC

-- 8.	Customers by Criteria
SELECT FirstName, Age, PhoneNumber
FROM Customers c
JOIN Countries cc ON cc.Id = c.CountryId
WHERE c.Age >= 21 AND c.FirstName LIKE '%an%' OR c.PhoneNumber LIKE '%38' AND cc.Name <> 'Greece'
ORDER BY c.FirstName ASC, c.Age DESC

-- 9.	Middle Range Distributors
SELECT *
FROM
(SELECT d.Name AS DistributorName, i.Name AS IngredientName, p.Name AS ProductName, AVG(f.Rate) AS Average
FROM Distributors d
JOIN Ingredients i ON i.DistributorId = d.Id
JOIN ProductsIngredients pi ON pi.IngredientId = i.Id
JOIN Products p ON p.Id = pi.ProductId
JOIN Feedbacks f ON f.ProductId = p.Id
GROUP BY p.Id, p.Name, d.Name, i.Name) a
WHERE a.Average BETWEEN 5 AND 8
ORDER BY a.DistributorName, a.IngredientName, a.ProductName

-- 10.	Country Representative
SELECT r.CountryName, r.DisributorName
FROM(
	SELECT c.Name AS CountryName, d.Name AS DisributorName, DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Rank
	FROM Countries c
	JOIN Distributors d ON d.CountryId = c.Id
	LEFT JOIN Ingredients i ON i.DistributorId = d.Id
	GROUP BY c.Name, d.Name
) AS r
WHERE r.Rank = 1
ORDER BY r.CountryName, r.DisributorName


-- 11.	Customers with Countries
GO
CREATE OR ALTER VIEW v_UserWithCountries
AS
	SELECT 
		CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
		, c.Age
		,c.Gender
		,cc.Name AS CountryName
	FROM Customers c 
	JOIN Countries cc ON c.CountryId = cc.Id
GO

-- 12. Delete Products
CREATE TRIGGER tr_OnDeleteProduct  ON Products INSTEAD OF DELETE
AS
	DECLARE @productId INT = (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients WHERE ProductId = @productId
	DELETE FROM Feedbacks WHERE ProductId = @productId
	DELETE FROM Products WHERE Id = @productId
GO

DELETE FROM Products WHERE Id = 7





