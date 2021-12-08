using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Enums;
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

        public async Task RequestMedicationsAsync(RequestMedicationsSPParams sPParams)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("RequestMedications");

                spBuilder.AddParameter("@userId", sPParams.UserId);
                spBuilder.AddParameter("@medicationId", sPParams.MedicationId);
                spBuilder.AddParameter("@pharmacyId", sPParams.PharmacyId);
                spBuilder.AddParameter("@quantity", sPParams.Quantity);
                spBuilder.AddParameter("@status", sPParams.Status);

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

        public async Task CancelMedicationsAsync(CancelMedicationsSPParams sPParams)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("CancelMedications");

                spBuilder.AddParameter("@userId", sPParams.UserId);
                spBuilder.AddParameter("@medicationId", sPParams.MedicationId);
                spBuilder.AddParameter("@pharmacyId", sPParams.PharmacyId);
                spBuilder.AddParameter("@status", sPParams.Status);

                using (var executor = spBuilder.Build())
                {
                    await executor.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                throw new MedException("There was an error canceling medications");
            }
        }

        public async Task<IList<GetMedicationsInfoSPResult>> GetMedicationsInfoAsync()
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetMedicationsInfo");

                spBuilder.AddParameter("@requestedStatus", OrderStatus.Requested);

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
