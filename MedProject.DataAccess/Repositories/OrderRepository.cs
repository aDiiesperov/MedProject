using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal class OrderRepository : Repository<OrderItem, OrderDataStore>, IOrderRepository
    {
        public OrderRepository(OrderDataStore store) : base(store)
        {
        }

        public Task<OrderGetByIdSPResult> GetByIdAsync(int id)
        {
            return this.store.GetByIdAsync(id);
        }

        public Task<IList<OrderGetAllByUserSPResult>> GetAllByUserAsync(int userId)
        {
            return this.store.GetAllByUserAsync(userId);
        }

        public async Task InsertAsync(OrderInsertSPParams sPParams)
        {
            await this.store.InsertAsync(sPParams);
        }

        public async Task UpdateAsync(OrderUpdateSPParams sPParams)
        {
            await this.store.UpdateAsync(sPParams);
        }
    }
}
