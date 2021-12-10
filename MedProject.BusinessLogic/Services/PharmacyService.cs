using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Services.Interfaces;
using MedProject.BusinessLogic.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedProject.DataAccess.DataStores.Interfaces;

namespace MedProject.BusinessLogic.Services
{
    internal class PharmacyService : BaseService<IPharmacyDataStore>, IPharmacyService
    {
        public PharmacyService(IPharmacyDataStore store) : base(store)
        {
        }

        public async Task<IList<PharmacyDto>> GetAssignedAsync(int userId)
        {
            var list = await this.store.GetAssignedAsync(userId);
            return list.Select(p => p.MapToDto()).ToList();
        }

        public async Task<IList<PharmacyDto>> GetListAsync()
        {
            var list = await this.store.GetAllAsync();
            return list.Select(p => p.MapToDto()).ToList();
        }
    }
}
