-- Problem 10.	Add Check Constraint

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeastFiveSymbols CHECK(LEN([Password]) >= 5)
