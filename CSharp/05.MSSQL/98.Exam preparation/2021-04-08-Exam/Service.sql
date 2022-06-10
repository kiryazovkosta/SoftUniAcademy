CREATE DATABASE [Service]
GO

USE [Service]
GO

-- 1. Table design
CREATE TABLE Users
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Username VARCHAR(30) NOT NULL UNIQUE
	,[Password] VARCHAR(50) NOT NULL
	,[Name]	VARCHAR(50)
	,Birthdate DATETIME
	,Age INT CHECK(Age BETWEEN 14 AND 110)
	,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name]	VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName VARCHAR(25)
	,LastName VARCHAR(25)
	,Birthdate DATETIME
	,Age INT CHECK(Age BETWEEN 18 AND 110)
	,DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,CategoryId INT NOT NULL REFERENCES Categories(Id)
	,StatusId INT NOT NULL REFERENCES [Status](Id)
	,OpenDate DATETIME NOT NULL
	,CloseDate DATETIME
	,[Description] VARCHAR(200) NOT NULL
	,UserId INT NOT NULL REFERENCES Users(Id)
	,EmployeeId INT REFERENCES Employees(Id)
)

--2. Insert
INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId)
VALUES
	('Marlo','O''Malley','1958-9-21',1),
	('Niki','Stanaghan','1969-11-26',4),
	('Ayrton','Senna','1960-03-21',9),
	('Ronnie','Peterson','1944-02-14',9),
	('Giovanna','Amati','1959-07-20',5)
INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId)
VALUES
	(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
	(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
	(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5, 2),
	(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11', 1, 1)

-- 3. Update
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- 4. Delete
DELETE
FROM Reports
WHERE StatusId = 4

-- 5. Unassigned Reports
SELECT r.Description, FORMAT(r.OpenDate, 'dd-MM-yyyy')
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate ASC, r.[Description] ASC

--6. Reports & Categories
SELECT r.Description, c.Name
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
WHERE CategoryId Is NOT NULL
ORDER BY r.Description ASC, c.Name ASC

-- 7. Most Reported Category
SELECT TOP(5)
	c.Name AS CategoryName, 
	COUNT(*) AS ReportsNumber
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName ASC

-- 8. Birthday Report
SELECT 
	u.Username AS Username
	,c.Name AS CategoryName
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
JOIN Users u ON u.Id = r.UserId
WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
	AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
ORDER BY Username ASC, CategoryName ASC

-- 9. Users per Employee
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,COUNT(u.Id) AS UsersCount
FROM Employees e
LEFT JOIN Reports r ON e.Id = r.EmployeeId
LEFT JOIN Users u ON u.Id = r.UserId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC, FullName ASC

--10. Full Info
SELECT 
	IIF(r.EmployeeId IS NULL, 'None', CONCAT(e.FirstName, ' ', e.LastName)) As Employee
	,IIF(e.DepartmentId IS NULL, 'None', d.[Name]) AS Department
	,c.[Name] AS Category
	,r.[Description] AS [Description]
	,FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
	,s.[Label] AS [Status]
	,u.[Name] AS [User]
FROM Reports r
LEFT JOIN Employees e ON e.Id = r.EmployeeId
LEFT JOIN Departments d ON d.Id = e.DepartmentId
LEFT JOIN Categories c ON c.Id = r.CategoryId
LEFT JOIN Status s ON s.Id = r.StatusId
LEFT JOIN Users u ON u.Id = r.UserId
ORDER BY 
	e.FirstName DESC
	,e.LastName DESC
	,Department ASC
	,Category ASC
	,Description ASC
	,OpenDate ASC
	,Status ASC
	, User ASC

--11. Hours to Complete
GO
CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0;

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

GO

--12. Assign Employee
GO
CREATE OR ALTER PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
	DECLARE @reportDepartmentId INT = (SELECT DepartmentId
										FROM Categories c
										JOIN Reports r ON r.CategoryId = c.Id 
										WHERE r.Id = @ReportId)
	IF(@employeeDepartmentId IS NULL OR @reportDepartmentId IS NULL OR @employeeDepartmentId <> @reportDepartmentId)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports 
	SET EmployeeId = @EmployeeId 
	WHERE Id = @ReportId 
END

GO
EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2

