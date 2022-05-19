-- 7.	Define Function
-- Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false depending on that if the word is a comprised of the given set of letters. 

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @output BIT = 1;
	DECLARE @length INT = LEN(@word)
	DECLARE @index INT = 1;
	WHILE (@index <= @length)
	BEGIN
		IF(CHARINDEX(SUBSTRING(@word, @index, 1), @setOfLetters,  1) <= 0)
		BEGIN
			SET @output = 0;
			BREAK;
		END
		SET @index = @index + 1;
	END

	RETURN @output
END
GO

SELECT
	dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
	,dbo.ufn_IsWordComprised('oistmiahf', 'halves')
	,dbo.ufn_IsWordComprised('bobr', 'Rob')
	,dbo.ufn_IsWordComprised('pppp', 'Guy')