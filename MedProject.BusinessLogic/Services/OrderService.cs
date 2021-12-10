using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Enums;
using MedProject.BusinessLogic.Services.Interfaces;
using MedProject.DataAccess.DataStores.Interfaces;
using MedProject.DataAccess.DataStores.Models;
using MedProject.Shared.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal class OrderService : BaseService<IOrderDataStore>, IOrderService
    {
        public OrderService(IOrderDataStore store) : base(store)
        {
        }

        public async Task QueryAsync(int userId, MedicationRequestDto model)
        {
            var order = await this.GetOrderAsync(userId, model.MedicationId, model.PharmacyId);

            if (order == null)
            {
                var createModel = new OrderInsertSPParams()
                {
                    UserId = userId,
                    MedicationId = model.MedicationId,
                    PharmacyId = model.PharmacyId,
                    Quantity = model.Quantity,
                    Status = (byte)OrderStatus.Requested,
                };

                await this.store.InsertAsync(createModel);
            }
            else
            {
                var updateModel = new OrderUpdateSPParams()
                {
                    Id = order.Id,
                    Quantity = model.Quantity,
                    Status = (byte)OrderStatus.Requested,
                };

                await this.store.UpdateAsync(updateModel);
            }


        }

        public async Task CancelAsync(int userId, MedicationCancelDto model)
        {
            var order = await this.GetOrderAsync(userId, model.MedicationId, model.PharmacyId);

            if (order == null)
            {
                throw new MedException("An error occurred while canceling order");
            }
            else
            {
                var updateModel = new OrderUpdateSPParams()
                {
                    Id = order.Id,
                    Status = (byte)OrderStatus.Canceled
                };

                await this.store.UpdateAsync(updateModel);
            }
        }

        private async Task<OrderGetAllByUserSPResult> GetOrderAsync(int userId, int medicationId, int pharmacyId)
        {
            var orders = await this.store.GetAllByUserAsync(userId);
            return orders.FirstOrDefault(order => order.MedicationId == medicationId &&
                                                            order.PharmacyId == pharmacyId);
        }

        public async Task AcceptAsync(int orderId)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Status = (byte)OrderStatus.Accepted
            };

            await this.store.UpdateAsync(updateModel);
        }

        public async Task CancelAsync(int orderId)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Status = (byte)OrderStatus.Canceled
            };

            await this.store.UpdateAsync(updateModel);
        }

        public async Task NotifyPatientAsync(int orderId, double quantity)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Available = quantity,
                Status = (byte)OrderStatus.Avaliable,
            };

            await this.store.UpdateAsync(updateModel);
        }
    }
}
