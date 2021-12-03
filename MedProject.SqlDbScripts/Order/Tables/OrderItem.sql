CREATE TABLE [dbo].[OrderItem]
(
	[Id] INT PRIMARY KEY IDENTITY,
    [UserId] INT NOT NULL FOREIGN KEY REFERENCES MedUsers(Id),
    [MedicationId] INT NOT NULL FOREIGN KEY REFERENCES Medications(Id),
    [PharmacyId] INT NOT NULL FOREIGN KEY REFERENCES Pharmacies(Id),
    [Quantity] FLOAT NOT NULL,
    [Status] TINYINT NOT NULL DEFAULT 0,
    [Available] FLOAT NULL,
    CONSTRAINT AK_UserId_PharmacyId_MedicationId UNIQUE(UserId, PharmacyId, MedicationId)
)
