using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Interfaces;
using MedProject.DataAccess.DataStores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class PharmacyDataStore : BaseDataStore, IPharmacyDataStore
    {
        public PharmacyDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public Task<IList<GetAllPharmaciesSPResult>> GetAllAsync()
        {
            return this.adoManager.GetAllByProcAsync<GetAllPharmaciesSPResult>("GetAllPharmacies");
        }

        public async Task<IList<GetAllPharmaciesSPResult>> GetAssignedAsync(int userId)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetAssignedPharmacies");

                spBuilder.AddParameter("@userId", userId);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadAllAsync<GetAllPharmaciesSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
