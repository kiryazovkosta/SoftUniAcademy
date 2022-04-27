-- Problem 9.	*Peaks in Rila
SELECT M.[MountainRange],P.[PeakName],[Elevation]
FROM [Peaks] AS P
INNER JOIN [Mountains] AS M ON M.[Id] = P.[MountainId]
WHERE M.[MountainRange] = 'Rila'
ORDER BY P.Elevation DESC