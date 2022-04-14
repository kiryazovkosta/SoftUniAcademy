-- Problem 3. Alter Minions Table
USE Minions
GO

ALTER TABLE Minions ADD TownId INT;
ALTER TABLE Minions ADD FOREIGN KEY (TownId) REFERENCES Towns(Id);