-- 14. Countries with Rivers

SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
WHERE cn.ContinentName = 'Africa'
ORDER BY c.CountryName ASC