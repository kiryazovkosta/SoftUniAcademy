-- Problem 11.	Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETUTCDATE() FOR LastLogginTime