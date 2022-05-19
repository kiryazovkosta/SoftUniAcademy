-- 13.	*Scalar Function: Cash in User Games Odd Rows

-- Create a function ufn_CashInUsersGames that sums the cash of odd rows. Rows must be ordered by cash in descending order. 
-- The function should take a game name as a parameter and return the result as table. Submit only your function in.
-- Execute the function over the following game names, ordered exactly like: "Love in a mist".

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS 
	RETURN SELECT(
		SELECT SUM(rns.Cash) AS [SumCash]
		FROM
		(
			SELECT 
				g.Name
				,ug.Cash
				,ROW_NUMBER() OVER(PARTITION BY g.Name ORDER BY ug.Cash DESC) AS RowNumber
			FROM UsersGames ug
			INNER JOIN Games g ON ug.GameId = g.Id
			WHERE g.Name = @gameName
		) AS rns
		WHERE RowNumber % 2 <> 0
	) As [SumCash]

GO

SELECT * FROM ufn_CashInUsersGames('Love in a mist');


