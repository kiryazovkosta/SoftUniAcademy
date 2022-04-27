-- Problem 3.	Many-To-Many Relationship

CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(32) NOT NULL
)

INSERT INTO Students(Name) VALUES ('Mila');
INSERT INTO Students(Name) VALUES ('Toni');
INSERT INTO Students(Name) VALUES ('Ron');

CREATE TABLE Exams
(
ExamID INT NOT NULL PRIMARY KEY IDENTITY(101, 1),
[Name] NVARCHAR(32) NOT NULL
)

INSERT INTO Exams(Name) VALUES ('SpringMVC');
INSERT INTO Exams(Name) VALUES ('Neo4j');
INSERT INTO Exams(Name) VALUES ('Oracle 11g');

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentExam PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Student FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Exam FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES 
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103)
