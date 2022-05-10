-- 15. *Continents and Currencies

SELECT r.ContinentCode, r.CurrencyCode, r.Count
FROM 
(
	SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [Count], DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank] 
	FROM Countries AS c
	GROUP BY c.ContinentCode, c.CurrencyCode
) AS r
WHERE r.rank = 1 and r.Count > 1