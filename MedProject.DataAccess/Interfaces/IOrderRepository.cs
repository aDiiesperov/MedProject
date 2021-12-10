using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Interfaces
{
    public interface IOrderRepository : IRepository<OrderItem>
    {
        Task<OrderGetByIdSPResult> GetByIdAsync(int id);

        Task<IList<OrderGetAllByUserSPResult>> GetAllByUserAsync(int userId);

        Task InsertAsync(OrderInsertSPParams sPParams);

        Task UpdateAsync(OrderUpdateSPParams sPParams);
    }
}
