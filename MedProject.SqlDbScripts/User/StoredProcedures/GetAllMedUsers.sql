CREATE OR ALTER PROCEDURE [dbo].[GetAllMedUsers]
AS
	SELECT U.Id, U.FirstName, U.LastName, U.LoginName, U.PasswordHash,
			S.Id StateId, S.Name StateName, S.Abbreviation StateAbbreviation,
			R.Id RoleId, R.Name RoleName,
			P.Id PharmacyId, P.Name PharmacyName, P.Address PharmacyAddress, P.Email PharmacyEmail, P.Phone PharmacyPhone,
			PS.Id PharmacyStateId, PS.Name PharmacyStateName, PS.Abbreviation PharmacyStateAbbreviation
	FROM MedUsers U
	LEFT JOIN States S ON S.Id = U.StateId
	LEFT JOIN MedUsersRoles UR ON U.Id = UR.UserId
	LEFT JOIN MedRoles R ON R.Id = UR.RoleId
	LEFT JOIN MedUsersPharmacies UP ON U.Id = UP.UserId
	LEFT JOIN Pharmacies P ON P.Id = UP.PharmacyId
	LEFT JOIN States PS ON PS.Id = P.StateId