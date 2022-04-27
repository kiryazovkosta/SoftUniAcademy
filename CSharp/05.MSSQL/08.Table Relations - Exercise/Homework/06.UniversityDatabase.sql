-- 06. University Database

--CREATE DATABASE University
--GO

--USE University
--GO

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY,
	Name VARCHAR(50)
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY,
	StudentNuumber INT NOT NULL,
	StudentName NVARCHAR(100),
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL(8, 2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda (
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_Student_Subject PRIMARY KEY(StudentID, SubjectID)
)