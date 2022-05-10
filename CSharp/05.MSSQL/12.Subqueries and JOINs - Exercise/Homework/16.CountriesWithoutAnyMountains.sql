--16. Countries Without Any Mountains

SELECT COUNT(*) AS COUNT
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL