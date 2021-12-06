CREATE PROCEDURE [dbo].[GetAssignedPharmacies]
	@userId int
AS
	SELECT P.Id, P.Name, P.Address, P.Email, P.Phone,
			S.Id StateId, S.Name StateName, S.Abbreviation StateAbbreviation
	FROM Pharmacies P
	JOIN States S ON P.StateId = S.Id
	JOIN MedUsersPharmacies UP ON UP.PharmacyId = P.Id
	WHERE UP.UserId = @userId
