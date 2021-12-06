CREATE OR ALTER PROCEDURE [dbo].[GetMedicationsToOrder]
	@userId int
AS
	SELECT P.Id PharmacyId, P.Name Pharmacy, M.Id MedicationId, M.Name Medication, S.Quantity TotalQuantity, OI.Status Status, OI.Quantity OrderedQuantity, OI.Available Available
    FROM Medications M
	JOIN Stocks S ON S.MedicationId = M.Id
	JOIN Pharmacies P ON P.Id = S.PharmacyId
	JOIN MedUsersPharmacies UP ON UP.PharmacyId = P.Id
	LEFT JOIN OrderItem OI ON OI.UserId = UP.UserId AND OI.MedicationId = M.Id AND OI.PharmacyId = P.Id
	WHERE UP.UserId = @userId