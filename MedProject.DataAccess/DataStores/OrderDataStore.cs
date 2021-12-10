using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using MedProject.Shared.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class OrderDataStore : BaseDataStore<OrderItem>
    {
        public OrderDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public override Task<IList<OrderItem>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<OrderGetByIdSPResult> GetByIdAsync(int id)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("OrderGetById");

                spBuilder.AddParameter("@id", id);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadFirstAsync<OrderGetByIdSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<OrderGetAllByUserSPResult>> GetAllByUserAsync(int userId)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("OrderGetAllByUser");

                spBuilder.AddParameter("@userId", userId);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadAllAsync<OrderGetAllByUserSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task UpdateAsync(OrderUpdateSPParams sPParams)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("OrderInsertOrUpdate");

                spBuilder.AddParameter("@id", sPParams.Id);
                spBuilder.AddParameter("@quantity", sPParams.Quantity);
                spBuilder.AddParameter("@available", sPParams.Available);
                spBuilder.AddParameter("@status", sPParams.Status);

                using (var executor = spBuilder.Build())
                {
                    await executor.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                throw new MedException("An error occurred while updating order");
            }
        }

        public async Task InsertAsync(OrderInsertSPParams sPParams)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("OrderInsertOrUpdate");

                spBuilder.AddParameter("@userId", sPParams.UserId);
                spBuilder.AddParameter("@medicationId", sPParams.MedicationId);
                spBuilder.AddParameter("@pharmacyId", sPParams.PharmacyId);
                spBuilder.AddParameter("@quantity", sPParams.Quantity);
                spBuilder.AddParameter("@available", sPParams.Available);
                spBuilder.AddParameter("@status", sPParams.Status);

                using (var executor = spBuilder.Build())
                {
                    await executor.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                throw new MedException("An error occurred while inserting order");
            }
        }
    }
}
