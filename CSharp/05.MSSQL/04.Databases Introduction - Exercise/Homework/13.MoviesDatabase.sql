-- Problem 13. Movies Database

CREATE DATABASE Movies
GO

USE Movies
GO

CREATE TABLE Directors 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[DirectorName] NVARCHAR(50) NOT NULL, 
	[Notes] NVARCHAR(512)
)

CREATE TABLE Genres
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(512)
)

CREATE TABLE Categories 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[CategoryName] NVARCHAR(50) NOT NULL, 
	[Notes] NVARCHAR(512)
)

CREATE TABLE Movies
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Title] NVARCHAR(80), 
	[DirectorId] INT NOT NULL, 
	[CopyrightYear] SMALLINT NOT NULL, 
	[Length] INT NOT NULL, 
	[GenreId] INT NOT NULL, 
	[CategoryId] INT NOT NULL, 
	[Rating] TINYINT, 
	[Notes] NVARCHAR(512)
)

ALTER TABLE Movies ADD FOREIGN KEY (DirectorId) REFERENCES Directors(Id);
ALTER TABLE Movies ADD FOREIGN KEY (GenreId) REFERENCES Genres(Id);
ALTER TABLE Movies ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

INSERT INTO Directors(DirectorName, Notes)
VALUES
('Director1', NULL),
('Director2', 'Some notes for director2'),
('Director3', 'Some notes for director3'),
('Director4', NULL),
('Director5', 'Some notes for director5')

INSERT INTO Genres(GenreName, Notes)
VALUES
('Genre1', NULL),
('Genre2', 'Some notes for genre2'),
('Genre3', 'Some notes for genre3'),
('Genre4', 'Some notes for genre4'),
('Genre5', NULL)

INSERT INTO Categories(CategoryName, Notes)
VALUES
('Category1', 'Some notes for category1'),
('Category2', NULL),
('Category3', NULL),
('Category4', 'Some notes for category4'),
('Category5', NULL)

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
VALUES
('Movie1',2,1089,96,1,1,3,NULL),
('Movie2',3,2001,88,2,2,18, 'Notes for movie2'),
('Movie3',1,2013,112,3,3,13,NULL),
('Movie4',2,1996,132,4,1,16,NULL),
('Movie5',5,2002,78,5,2,13,'Notes for movie5')
