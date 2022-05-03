-- 13. Mix of Peak and River Names

SELECT P.PeakName, R.RiverName, LOWER(P.PeakName + SUBSTRING(R.RiverName, 2, LEN(R.RiverName) - 1)) As Mix
FROM Rivers AS R, Peaks AS P
WHERE LEFT(R.RiverName, 1) = RIGHT(P.PeakName, 1)
ORDER BY Mix ASC