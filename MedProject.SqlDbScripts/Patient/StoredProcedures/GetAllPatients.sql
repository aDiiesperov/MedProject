CREATE OR ALTER PROCEDURE GetAllPatients
AS
SELECT Id, FirstName, LastName, StateCode, PharmacyName, PharmacyAssignDate FROM Patients;
