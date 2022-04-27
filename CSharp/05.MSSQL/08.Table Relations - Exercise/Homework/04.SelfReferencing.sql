-- 04. Self-Referencing

CREATE TABLE Teachers
(
	TeacherID INT NOT NULL IDENTITY(101, 1),
	[Name] NVARCHAR(32) NOT NULL,
	ManagerID INT,
	CONSTRAINT PK_Teacher PRIMARY KEY(TeacherID),
	CONSTRAINT FK_Teacher_Manager FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted',	105),
	('Mark', 101),
	('Greta', 101)
