-- 12. Highest Peaks in Bulgaria

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks p
INNER JOIN Mountains m ON m.Id = p.MountainId
INNER JOIN MountainsCountries mc ON mc.MountainId = m.Id 
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC