CREATE OR ALTER PROCEDURE GetAllPharmacies
AS
SELECT Id, Name, StateCode, Address, Email, Phone FROM Pharmacies;
