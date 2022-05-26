SELECT 
	JobDuringJourney
	,FullName
	,JobRank
FROM
(
	SELECT 
		tc.JobDuringJourney AS JobDuringJourney
		,c.FirstName + ' ' + c.LastName AS FullName
		,DENSE_RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	FROM TravelCards tc
	JOIN Colonists c ON c.Id = tc.ColonistId
	GROUP BY tc.JobDuringJourney, c.BirthDate, c.FirstName, c.LastName
) AS Result
WHERE JobRank = 2