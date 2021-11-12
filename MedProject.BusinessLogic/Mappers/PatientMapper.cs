using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.Models;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class PatientMapper
    {
        public static PatientDto MapToDto(this Patient model)
        {
            return new PatientDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StateCode = model.StateCode,
                PharmacyName = model.PharmacyName,
                PharmacyAssignDate = model.PharmacyAssignDate,
            };
        }
    }
}
