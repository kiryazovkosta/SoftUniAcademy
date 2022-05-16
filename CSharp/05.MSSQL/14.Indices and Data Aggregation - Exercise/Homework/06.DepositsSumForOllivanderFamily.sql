-- 06. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup