CREATE OR ALTER PROCEDURE [dbo].[RequestMedications]
	@userId INT,
	@medicationId INT,
	@pharmacyId INT,
	@quantity FLOAT,
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
		UPDATE OrderItem SET Quantity = @quantity, Status = @status;
	ELSE
		INSERT INTO OrderItem(UserId, MedicationId, PharmacyId, Status, Quantity)
		VALUES (@userId, @medicationId, @PharmacyId, @status, @quantity);
END;