CREATE OR ALTER PROCEDURE GetUserByLogin
	@loginName VARCHAR(100)
AS
	SELECT U.Id, U.FirstName, U.LastName, U.LoginName, U.PasswordHash,
			R.Name RolesName
	FROM MedUsers U
	LEFT JOIN MedUsersRoles UR ON UR.UserId = U.Id
	LEFT JOIN MedRoles R ON R.Id = UR.RoleId
	WHERE LoginName = @loginName;
