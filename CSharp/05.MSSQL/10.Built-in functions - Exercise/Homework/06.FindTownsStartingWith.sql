-- 06. Find Towns Starting With

SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name ASC