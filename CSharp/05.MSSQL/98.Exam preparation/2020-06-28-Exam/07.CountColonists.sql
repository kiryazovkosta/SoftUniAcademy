SELECT COUNT(*) as [count]
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.Id
JOIN Journeys j ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'