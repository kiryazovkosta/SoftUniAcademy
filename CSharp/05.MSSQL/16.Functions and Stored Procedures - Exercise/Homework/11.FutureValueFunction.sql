-- 11.	Future Value Function
-- Your task is to create a function ufn_CalculateFutureValue that accepts as parameters – sum (decimal), yearly interest rate (float) and number of years(int). 
-- It should calculate and return the future value of the initial sum rounded to the fourth digit after the decimal delimiter. Using the following formula:
-- FV=I×((1+R)^T)

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum MONEY, @rate FLOAT, @years int)
RETURNS MONEY
AS
BEGIN
	DECLARE @output MONEY = @sum * POWER(1 + @rate, @years);
	RETURN @output;
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
