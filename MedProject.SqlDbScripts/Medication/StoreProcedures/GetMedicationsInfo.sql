CREATE OR ALTER PROCEDURE [dbo].[GetMedicationsInfo]
@requestedStatus tinyint
AS
	SELECT P.Name Pharmacy, M.Name Medication, S.Quantity TotalQuantity,
		OI.Id ItemOrdersId, U.FirstName + ' ' + U.LastName ItemOrdersUserName, OI.Quantity ItemOrdersOrderedQuantity
    FROM Medications M
	JOIN Stocks S ON S.MedicationId = M.Id
	JOIN Pharmacies P ON P.Id = S.PharmacyId
	LEFT JOIN OrderItem OI ON OI.MedicationId = M.Id AND OI.PharmacyId = P.Id AND OI.Status = @requestedStatus
	LEFT JOIN MedUsers U ON U.Id = OI.UserId