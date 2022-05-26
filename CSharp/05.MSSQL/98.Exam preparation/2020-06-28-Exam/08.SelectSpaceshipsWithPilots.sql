SELECT s.[Name], s.[Manufacturer]
FROM Spaceships s
JOIN Journeys j ON j.SpaceshipId = s.Id
JOIN TravelCards tc ON tc.JourneyId = j.Id
JOIN Colonists c ON c.Id = tc.ColonistId
WHERE DATEDIFF(year, c.BirthDate, '2019-01-01') < 30 AND tc.JobDuringJourney = 'Pilot'
GROUP BY s.[Name], s.[Manufacturer]
ORDER BY s.[Name] ASC