CREATE TABLE [dbo].[Stocks]
(
	[Id] INT PRIMARY KEY IDENTITY,
    [PharmacyId] INT NOT NULL FOREIGN KEY REFERENCES Pharmacies(Id), 
    [MedicationId] INT NOT NULL FOREIGN KEY REFERENCES Medications(Id), 
    [Quantity] FLOAT NOT NULL DEFAULT 0,
    -- Price
)
