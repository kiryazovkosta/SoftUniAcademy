-- 13. Count Mountain Ranges
SELECT c.CountryCode, COUNT(*) AS MountainRanges
FROM Mountains m
JOIN MountainsCountries mc ON mc.MountainId = m.Id
JOIN Countries c ON C.CountryCode = mc.CountryCode
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode