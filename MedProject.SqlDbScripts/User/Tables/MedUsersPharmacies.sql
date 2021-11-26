﻿CREATE TABLE [dbo].[MedUsersPharmacies]
(
	Id INT PRIMARY KEY IDENTITY, 
    UserId INT NOT NULL FOREIGN KEY REFERENCES MedUsers(Id),
    PharmacyId INT NOT NULL FOREIGN KEY REFERENCES Pharmacies(Id),
    CONSTRAINT AK_UserId_PharmacyId UNIQUE(UserId, PharmacyId)
);
