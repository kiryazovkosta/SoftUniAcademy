-- 12. Rich Wizard, Poor Wizard

SELECT SUM(DepositAmount - GuestAmount)
FROM
(
	SELECT
		FirstName As Host,
		DepositAmount,
		LEAD(FirstName) OVER(ORDER BY Id) AS Guest,
		LEAD(DepositAmount) OVER(ORDER BY Id) AS GuestAmount
	FROM WizzardDeposits
) AS Guests