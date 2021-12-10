using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Interfaces;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.DataStores.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class OrderDataStore : BaseDataStore, IOrderDataStore
    {
        public OrderDataStore(AdoManager adoManager) : base(adoManager)
        {
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
                // TODO: LOG EXCEPTION
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
                // TODO: LOG EXCEPTION
                return null;
            }
        }

        public async Task<DbResult> UpdateAsync(OrderUpdateSPParams sPParams)
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
                    return DbResult.Success;
                }
            }
            catch
            {
                return DbResult.DatabaseError; // throw new MedException("An error occurred while updating order");
            }
        }

        public async Task<DbResult> InsertAsync(OrderInsertSPParams sPParams)
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
                    return DbResult.Success;
                }
            }
            catch
            {
                return DbResult.DatabaseError; // throw new MedException("An error occurred while inserting order");
            }
        }
    }
}
