using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.BusinessLogic.Mappers;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal class PharmacyService : CrudService<PharmacyDto, Pharmacy, IPharmacyRepository>, IPharmacyService
    {
        public PharmacyService(IPharmacyRepository repository) : base(repository)
        {
        }

        public async Task<IList<PharmacyDto>> GetAssignedAsync(int userId)
        {
            var list = await this.repository.GetAssignedAsync(userId);
            return list.Select(p => p.MapToDto()).ToList();
        }

        protected override PharmacyDto MapToDto(Pharmacy model)
        {
            return model.MapToDto();
        }
    }
}
