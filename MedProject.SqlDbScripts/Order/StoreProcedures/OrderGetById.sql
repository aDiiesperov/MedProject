CREATE OR ALTER PROCEDURE [dbo].[OrderGetById]
	@id int
AS
	SELECT Quantity, Status, Available
	FROM OrderItem
	WHERE Id = @id

