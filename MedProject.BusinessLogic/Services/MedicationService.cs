using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Services.Interfaces;
using MedProject.BusinessLogic.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedProject.BusinessLogic.Enums;
using MedProject.DataAccess.DataStores.Interfaces;

namespace MedProject.BusinessLogic.Services
{
    internal class MedicationService : BaseService<IMedicationDataStore>,  IMedicationService
    {
        public MedicationService(IMedicationDataStore store) : base(store)
        {
        }

        public async Task<IList<MedicationToOrderDto>> GetMedicationsToOrderAsync(int userId)
        {
            var list = await this.store.GetMedicationsToOrderAsync(userId);
            return list.Select(i => i.MapToDto()).ToList();
        }

        public async Task<IList<MedicationInfoDto>> GetMedicationsInfoAsync()
        {
            var requestedStatus = (byte)OrderStatus.Requested;
            var list = await this.store.GetMedicationsInfoAsync(requestedStatus);
            return list.Select(i => i.MapToDto()).ToList();
        }
    }
}
