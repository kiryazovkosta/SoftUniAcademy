-- 8.	* Delete Employees and Departments
-- Write a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT) which deletes all Employees from a given department. 
-- Delete these departments from the Departments table too. Finally SELECT the number of employees from the given department. 
-- If the delete statements are correct the select query should return 0.
-- After completing that exercise restore your database to revert all changes.

--SELECT EmployeeID
--FROM Employees e
--WHERE DepartmentID = 4

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	SELECT EmployeeID 
	INTO #DeletedEmployeeIds
	FROM Employees 
	WHERE DepartmentID = @departmentId

	DELETE FROM EmployeesProjects 
	WHERE EmployeeID IN (SELECT EmployeeID FROM #DeletedEmployeeIds)

	UPDATE Employees SET ManagerID = NULL 
	WHERE ManagerID IN (SELECT EmployeeID FROM #DeletedEmployeeIds)

	ALTER TABLE Departments ALTER COLUMN ManagerID INT NULL
	UPDATE Departments SET ManagerID = NULL 
	WHERE ManagerID IN (SELECT EmployeeID FROM #DeletedEmployeeIds)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 4