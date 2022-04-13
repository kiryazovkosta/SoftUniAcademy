-- Problem 12.	Set Unique Field
ALTER TABLE Users 
DROP CONSTRAINT PK_Users

ALTER TABLE Users 
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

ALTER TABLE Users 
ADD CONSTRAINT CH_UsernameMustBeAtLeastThreeSymbols CHECK(LEN(Username) >= 3)

ALTER TABLE Users 
ADD CONSTRAINT UH_UsernameIsUnique UNIQUE(Username)