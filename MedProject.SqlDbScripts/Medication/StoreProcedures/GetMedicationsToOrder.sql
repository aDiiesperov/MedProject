CREATE PROCEDURE [dbo].[GetMedicationsToOrder]
	@userId int
AS
	SELECT P.Id PharmacyId, P.Name Pharmacy, M.Id MedicationId, M.Name Medication, S.Quantity Quantity, OI.Status OrderStatus, OI.Available Available
    FROM Medications M
	JOIN Stocks S ON S.MedicationId = M.Id
	JOIN Pharmacies P ON P.Id = S.PharmacyId
	JOIN MedUsersPharmacies UP ON UP.PharmacyId = P.Id
	LEFT JOIN OrderItem OI ON OI.UserId = UP.UserId AND OI.MedicationId = M.Id AND OI.PharmacyId = P.Id
	WHERE UP.UserId = @userId