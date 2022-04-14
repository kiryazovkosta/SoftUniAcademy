-- 24.	Countries and Currency (Euro / Not Euro)

USE [Geography]
GO

SELECT CountryName, CountryCode, IIF(CurrencyCode = 'EUR','Euro','Not Euro') AS Currency FROM Countries
ORDER BY CountryName ASC