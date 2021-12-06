using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using MedProject.Shared.Exceptions;
using System;
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

        public async Task RequestMedicationsAsync(RequestMedicationsSPParams model)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("RequestMedications");

                spBuilder.AddParameter("@userId", model.UserId);
                spBuilder.AddParameter("@medicationId", model.MedicationId);
                spBuilder.AddParameter("@pharmacyId", model.PharmacyId);
                spBuilder.AddParameter("@quantity", model.Quantity);
                spBuilder.AddParameter("@status", model.Status);

                using (var executor = spBuilder.Build())
                {
                    await executor.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                throw new MedException("There was an error requesting medications");
            }
        }
    }
}
