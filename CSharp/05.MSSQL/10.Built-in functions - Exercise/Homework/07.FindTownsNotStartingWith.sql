-- 07. Find Towns Not Starting With

SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name ASC