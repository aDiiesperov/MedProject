using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class MedicationDataStore : BaseDataStore<Medication>
    {
        public MedicationDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public override Task<IList<Medication>> GetAllAsync()
        {
            throw new System.NotImplementedException();
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
    }
}
