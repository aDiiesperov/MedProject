using MedProject.BusinessLogic.Models;
using MedProject.DataAccess.DataStores.Models;
using System.Linq;

namespace MedProject.BusinessLogic.Mappers
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
                Roles = model.Roles.Select(r => new MedRole() { Id = r.Id, Name = r.Name }).ToList(),
            };
        }
    }
}
