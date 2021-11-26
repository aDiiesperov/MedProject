CREATE OR ALTER PROCEDURE GetUsersByRole
	@role VARCHAR(50)
AS
	SELECT U.Id, U.FirstName, U.LastName,
			S.Abbreviation StateAbbreviation,
			P.Id PharmaciesId, P.Name PharmaciesName
	FROM MedUsers U
	LEFT JOIN MedUsersPharmacies UP ON U.Id = UP.UserId
	LEFT JOIN Pharmacies P ON P.Id = UP.PharmacyId
	LEFT JOIN States S ON S.Id = U.StateId
	WHERE EXISTS (SELECT 1 FROM MedUsers inner_U
					JOIN MedUsersRoles inner_UR ON inner_U.Id = inner_UR.UserId
					JOIN MedRoles inner_R ON inner_R.Id = inner_UR.RoleId
					WHERE inner_U.Id = U.Id AND inner_R.Name = @role)