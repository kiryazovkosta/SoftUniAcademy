CREATE DATABASE CigarShop
GO

USE CigarShop
GO

--1. Database design
CREATE TABLE Sizes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25)
	,RingRange DECIMAL(18, 2) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,TasteType VARCHAR(20) NOT NULL
	,TasteStrength VARCHAR(15)	NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id	INT NOT NULL PRIMARY KEY IDENTITY
	,BrandName VARCHAR(30) NOT NULL UNIQUE
	,BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,CigarName VARCHAR(80) NOT NULL
	,BrandId INT NOT NULL REFERENCES Brands(Id)
	,TastId	INT NOT NULL REFERENCES Tastes(Id)
	,SizeId	INT NOT NULL REFERENCES Sizes(Id)
	,PriceForSingleCigar DECIMAL(15, 2)	NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Town VARCHAR(30) NOT NULL
	,Country	NVARCHAR(30) NOT NULL
	,Streat NVARCHAR(100) NOT NULL
	,ZIP	VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Email NVARCHAR(50) NOT NULL
	,AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL REFERENCES Clients(Id)
	,CigarId INT NOT NULL REFERENCES Cigars(Id)
	,PRIMARY KEY(ClientId, CigarId)
)

-- 2. Insert
INSERT INTO Cigars(CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL)
VALUES
	('COHIBA ROBUSTO',							9,	1,	5,	15.50,	'cohiba-robusto-stick_18.jpg')
	,('COHIBA SIGLO I',							9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg')
	,('HOYO DE MONTERREY LE HOYO DU MAIRE',		14,	5,	11,	7.50,	'hoyo-du-maire-stick_17.jpg')
	,('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4,	15,	32.00,	'hoyo-de-san-juan-stick_20.jpg')
	,('TRINIDAD COLONIALES',					2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP)
VALUES
	('Sofia','Bulgaria','18 Bul. Vasil levski',1000)
	,('Athens','Greece','4342 McDonald Avenue', 10435)
	,('Zagreb','Croatia', '4333 Lauren Drive', 10000)

-- 3. Update
UPDATE c
SET c.PriceForSingleCigar += c.PriceForSingleCigar * 0.2
FROM Cigars c
JOIN Tastes t ON t.Id = c.TastId
WHERE t.TasteType = 'Spicy'

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

-- 4. Delete
ALTER TABLE Clients
ALTER COLUMN AddressId INT NULL

UPDATE Clients
SET AddressId = NULL
WHERE AddressId IN (
	SELECT Id
	FROM Addresses
	WHERE LEFT(Country, 1) = 'C'
)

DELETE FROM Addresses WHERE LEFT(Country, 1) = 'C'

-- 5. Cigars by Price
SELECT c.CigarName, c.PriceForSingleCigar, c.ImageURL
FROM Cigars c
ORDER BY c.PriceForSingleCigar ASC, c.CigarName DESC

-- 6. Cigars by Taste
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
FROM Cigars c
JOIN Tastes t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

-- 7. Clients without Cigars
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email
FROM Clients c
LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

-- 8. First 5 Cigars
SELECT TOP(5)
	c.CigarName
	,c.PriceForSingleCigar
	,c.ImageURL
FROM Cigars c
JOIN Sizes s ON s.Id = c.SizeId
WHERE s.Length >= 12 AND (c.CigarName LIKE '%CI%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC

-- 9. Clients with ZIP Codes
SELECT 
	FullName
	,Country
	,ZIP
	,Format(PriceForSingleCigar, 'C')
FROM
(
	SELECT 
		CONCAT(c.FirstName, ' ', c.LastName) as FullName
		,a.Country as Country
		,a.ZIP as ZIP
		,cg.PriceForSingleCigar
		,DENSE_RANK() OVER(PARTITION BY CONCAT(c.FirstName, ' ', c.LastName) ORDER BY cg.PriceForSingleCigar DESC ) AS Ranged
	FROM Clients c
	JOIN Addresses a ON a.Id = c.AddressId
	JOIN ClientsCigars cc ON cc.ClientId = c.Id
	JOIN Cigars cg ON cg.Id = cc.CigarId
	WHERE a.ZIP NOT LIKE '%[^0-9]%'
	GROUP BY CONCAT(c.FirstName, ' ', c.LastName), Country, ZIP, cg.PriceForSingleCigar
) AS Result
WHERE Ranged = 1

-- 10.	Cigars by Size
SELECT
	c.LastName
	,AVG(s.Length) AS CigarLength
	,CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients c
JOIN ClientsCigars cc ON cc.ClientId = c.Id
JOIN Cigars ccc ON cc.CigarId = ccc.Id
JOIN Sizes s ON ccc.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CigarLength DESC

-- 11. Client with Cigars
GO
CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(cc.CigarId)
			FROM ClientsCigars cc
			JOIN Clients c ON c.Id = cc.ClientId
			WHERE c.FirstName = @name)

END
GO

SELECT dbo.udf_ClientWithCigars('Betty')

-- 12.	Search for Cigar with Specific Taste
GO

CREATE OR ALTER PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT 
		c.CigarName
		,FORMAT(c.PriceForSingleCigar, 'C')
		,t.TasteType
		,b.BrandName
		,CAST(s.Length AS VARCHAR(10)) + ' cm'
		,CAST(s.RingRange AS VARCHAR(10)) + ' cm'
	FROM Cigars c
	JOIN Tastes t ON t.Id = c.TastId
	JOIN Sizes s ON s.Id = c.SizeId
	JOIN Brands b ON b.Id = c.BrandId
	WHERE t.TasteType = @taste
	ORDER BY s.Length ASC, s.RingRange DESC
END
GO

EXEC usp_SearchByTaste 'Woody'