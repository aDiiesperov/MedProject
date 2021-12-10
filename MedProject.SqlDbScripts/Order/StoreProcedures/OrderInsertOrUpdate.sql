CREATE OR ALTER PROCEDURE [dbo].[OrderInsertOrUpdate]
	@id int = NULL,
	@quantity float = NULL,
	@status tinyint = NULL,
	@available float = NULL,
	@userId int = NULL,
	@medicationId int = NULL,
	@pharmacyId int = NULL
AS
	IF @id IS NULL
		INSERT INTO OrderItem(UserId, MedicationId, PharmacyId, Quantity, Status, Available)
			VALUES (@userId, @medicationId, @pharmacyId, @quantity, @status, @available)
	ELSE
	BEGIN
		IF @quantity IS NOT NULL UPDATE OrderItem SET Quantity = @quantity WHERE Id = @id
		IF @status IS NOT NULL UPDATE OrderItem SET Status = @status WHERE Id = @id
		IF @available IS NOT NULL UPDATE OrderItem SET Available = @available WHERE Id = @id
	END