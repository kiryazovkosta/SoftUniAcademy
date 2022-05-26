CREATE OR ALTER FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	RETURN(
		SELECT COUNT(*)
		FROM Colonists c
		JOIN TravelCards tc ON tc.ColonistId = c.Id
		JOIN Journeys j ON j.Id = tc.JourneyId
		JOIN Spaceports s ON s.Id = j.DestinationSpaceportId
		JOIN Planets p ON p.Id = s.PlanetId
		WHERE p.[Name] = @PlanetName)
END