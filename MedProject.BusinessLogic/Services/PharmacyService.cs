using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.BusinessLogic.Mappers;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;

namespace MedProject.BusinessLogic.Services
{
    internal class PharmacyService : CrudService<PharmacyDto, Pharmacy, IPharmacyRepository>, IPharmacyService
    {
        public PharmacyService(IPharmacyRepository repository) : base(repository)
        {
        }

        protected override PharmacyDto MapToDto(Pharmacy model)
        {
            return model.MapToDto();
        }
    }
}
