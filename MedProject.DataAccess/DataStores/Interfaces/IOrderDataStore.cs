using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.DataStores.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.Interfaces
{
    public interface IOrderDataStore
    {
        Task<OrderGetByIdSPResult> GetByIdAsync(int id);

        Task<IList<OrderGetAllByUserSPResult>> GetAllByUserAsync(int userId);

        Task<DbResult> UpdateAsync(OrderUpdateSPParams sPParams);

        Task<DbResult> InsertAsync(OrderInsertSPParams sPParams);
    }
}
