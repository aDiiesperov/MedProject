using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.DataStores.Models;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class PharmacyMapper
    {
        public static PharmacyDto MapToDto(this GetAllPharmaciesSPResult model)
        {
            return new PharmacyDto()
            {
                Id = model.Id,
                Address = model.Address,
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                StateCode = model.State.Abbreviation,
            };
        }
    }
}
