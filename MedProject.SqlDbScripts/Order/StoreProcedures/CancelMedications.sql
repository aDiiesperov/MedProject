CREATE OR ALTER PROCEDURE [dbo].[CancelMedications]
	@userId INT,
	@medicationId INT,
	@pharmacyId INT,
	@status tinyint
AS
BEGIN
	DECLARE @orderId INT;

	SELECT @orderId = Id
	FROM OrderItem
	WHERE UserId = @userId AND
			MedicationId = @medicationId AND
			PharmacyId = @pharmacyId;

	IF (@orderId IS NOT NULL)
		UPDATE OrderItem SET Status = @status
		WHERE Id = @orderId;
	-- else add error
END;
