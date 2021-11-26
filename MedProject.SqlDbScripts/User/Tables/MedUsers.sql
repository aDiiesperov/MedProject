CREATE TABLE MedUsers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	LoginName VARCHAR(100) UNIQUE NOT NULL,
	PasswordHash CHAR(128) NOT NULL,
	StateId TINYINT FOREIGN KEY REFERENCES States(Id),
);
