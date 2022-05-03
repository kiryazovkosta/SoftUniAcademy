-- Problem 5.	Find Towns with Name Length

SELECT Name
FROM Towns
WHERE LEN(Name) IN (5,6)
ORDER BY Name ASC