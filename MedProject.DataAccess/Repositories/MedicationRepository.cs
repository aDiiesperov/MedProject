using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal class MedicationRepository : Repository<Medication, MedicationDataStore>, IMedicationRepository
    {
        public MedicationRepository(MedicationDataStore store) : base(store)
        {
        }

        public Task<IList<GetMedicationsToOrderSPResult>> GetMedicationsToOrderAsync(int userId)
        {
            return this.store.GetMedicationsToOrderAsync(userId);
        }

        public Task RequestMedicationsAsync(RequestMedicationsSPParams sPParams)
        {
            return this.store.RequestMedicationsAsync(sPParams);
        }

        public Task CancelMedicationsAsync(CancelMedicationsSPParams sPParams)
        {
            return this.store.CancelMedicationsAsync(sPParams);
        }

        public Task<IList<GetMedicationsInfoSPResult>> GetMedicationsInfoAsync()
        {
            return this.store.GetMedicationsInfoAsync();
        }
    }
}
