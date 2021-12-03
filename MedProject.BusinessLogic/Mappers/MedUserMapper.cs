using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.Models;
using System.Linq;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class MedUserMapper
    {
        public static MedUserDto MapToDto(this MedUser model)
        {
            return new MedUserDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StateCode = model.State.Abbreviation,
                Roles = model.Roles.MapToDto().ToList(),
            };
        }
    }
}
