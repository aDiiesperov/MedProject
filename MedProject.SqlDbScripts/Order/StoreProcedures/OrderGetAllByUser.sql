CREATE OR ALTER PROCEDURE [dbo].[OrderGetAllByUser]
	@userId INT
AS
	SELECT Id, MedicationId, PharmacyId, Quantity, Status, Available
	FROM OrderItem
	WHERE UserId = @userId
