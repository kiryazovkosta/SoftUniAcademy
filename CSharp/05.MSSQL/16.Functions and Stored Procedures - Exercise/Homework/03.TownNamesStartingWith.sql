-- 3.	Town Names Starting With
-- Write a stored procedure usp_GetTownsStartingWith that accept string as parameter and returns all town names starting with that string. 

CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith(@BeginText NVARCHAR(50))
AS
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @BeginText + '%'

EXEC usp_GetTownsStartingWith 'b'