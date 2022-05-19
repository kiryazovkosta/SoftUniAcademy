-- 5.	Salary Level Function
-- Write a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee and returns the level of the salary.
--•	If salary is < 30000 return "Low"
--•	If salary is between 30000 and 50000 (inclusive) return "Average"
--•	If salary is > 50000 return "High"

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @output NVARCHAR(10);
	IF @salary < 30000
		SET @output = 'Low';
	ELSE IF @salary > 50000
		SET @output = 'High';
	ELSE
		SET @output = 'Average';
	RETURN @output;
END
GO

SELECT 
	dbo.ufn_GetSalaryLevel(10000)
	,dbo.ufn_GetSalaryLevel(29999)
	,dbo.ufn_GetSalaryLevel(30000)
	,dbo.ufn_GetSalaryLevel(50000)
	,dbo.ufn_GetSalaryLevel(50001)