using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Linq;

namespace MedProject.DataAccess.Mapper
{
    public static class MedUserMapper
    {
        public static MedUser MapToEntity(this GetUserByLoginSPResult model)
        {
            return new MedUser()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LoginName = model.LoginName,
                PasswordHash = model.PasswordHash,
                Roles = model.Roles.Select(r => r.MapToEntity()).ToList(),
            };
        }

        public static MedRole MapToEntity(this GetUserByLoginSPResult.RoleSPResult model)
        {
            return new MedRole()
            {
                Name = model.Name,
            };
        }
    }
}
