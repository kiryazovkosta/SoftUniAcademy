SELECT	p.Name as PlanetName
	    , COUNT(*) as JourneysCount
FROM Planets p
JOIN Spaceports s ON s.PlanetId = p.Id
JOIN Journeys j ON j.DestinationSpaceportId = s.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC, PlanetName ASC