using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Interfaces;
using MedProject.DataAccess.DataStores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class MedicationDataStore : BaseDataStore, IMedicationDataStore
    {
        public MedicationDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public async Task<IList<GetMedicationsToOrderSPResult>> GetMedicationsToOrderAsync(int userId)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetMedicationsToOrder");

                spBuilder.AddParameter("@userId", userId);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadAllAsync<GetMedicationsToOrderSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<GetMedicationsInfoSPResult>> GetMedicationsInfoAsync(byte requestedStatus)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetMedicationsInfo");

                spBuilder.AddParameter("@requestedStatus", requestedStatus);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadAllAsync<GetMedicationsInfoSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
