-- Problem 8. Create Table Users
CREATE TABLE Users
(
	Id BIGINT NOT NULL IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLogginTime DATETIME,
	IsDeleted BIT,
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLogginTime, IsDeleted)
VALUES
('Kosta', 'strongPass123', '', '2022-04-11', 0),
('Ivan', 'poorPass', '', '2022-04-11', 0),
('Petar', '123456', '', '2022-04-11', 0),
('Any', '43234', '', '2022-03-01', 1),
('Stamat', 'a1s2d3', '', '2022-04-13', 0)