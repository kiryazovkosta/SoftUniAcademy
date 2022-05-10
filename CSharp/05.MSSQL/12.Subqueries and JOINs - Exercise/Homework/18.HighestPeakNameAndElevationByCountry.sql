--

SELECT TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
FROM
(
	SELECT 
		c.CountryName, 
		ISNULL(p.PeakName, '(no highest peak)') AS 'PeakName',
		ISNULL(m.MountainRange, '(no mountain)') AS 'MountainRange', 
		ISNULL(MAX(p.Elevation), 0) AS 'HighestPeak',
		DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) As Ranked
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY c.CountryName, p.PeakName, m.MountainRange, p.Elevation
) AS k
WHERE Ranked = 1
ORDER BY k.CountryName ASC, k.PeakName ASC

--SELECT TOP (5) WITH TIES 
--c.CountryName, 
--ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName', 
--ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', 
--ISNULL(m.MountainRange, '(no mountain)')
--FROM Countries AS c
--LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
--LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
--LEFT JOIN Peaks AS p ON m.Id = p.MountainId
--GROUP BY c.CountryName, p.PeakName, m.MountainRange
--ORDER BY c.CountryName, p.PeakName