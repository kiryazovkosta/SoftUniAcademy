-- Problem 9. Change Primary Key
ALTER TABLE Users 
DROP CONSTRAINT PK_Users

ALTER TABLE Users 
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)

