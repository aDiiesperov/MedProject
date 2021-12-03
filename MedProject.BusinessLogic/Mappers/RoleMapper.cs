using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class RoleMapper
    {
        public static MedRoleDto MapToDto(this MedRole model)
        {
            return new MedRoleDto()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static IEnumerable<MedRoleDto> MapToDto(this IEnumerable<MedRole> model)
        {
            return model.Select(m => m.MapToDto());
        }
    }
}
