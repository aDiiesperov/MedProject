using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.DataStores.Models;
using System.Linq;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class PatientMapper
    {
        public static PatientDto MapToDto(this GetUsersByRoleSPResult model)
        {
            return new PatientDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StateAbbreviation = model.StateAbbreviation,
                Pharmacies = model.Pharmacies.Select(p => p.MapToDto()).ToList(),
            };
        }

        public static PatientPharmacyDto MapToDto(this GetUsersByRoleSPResult.PharmacySPResult model)
        {
            return new PatientPharmacyDto()
            {
                Name = model.Name,
                AssignDate = model.AssignDate,
            };
        }
    }
}
