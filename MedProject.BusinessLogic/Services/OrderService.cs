using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Enums;
using MedProject.DataAccess.Interfaces;
using MedProject.Shared.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task RequestAsync(int userId, MedicationRequestDto model)
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
                    Status = OrderStatus.Requested,
                };

                await this.repository.InsertAsync(createModel);
            }
            else
            {
                var updateModel = new OrderUpdateSPParams()
                {
                    Id = order.Id,
                    Quantity = model.Quantity,
                    Status = OrderStatus.Requested,
                };

                await this.repository.UpdateAsync(updateModel);
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
                    Status = OrderStatus.Canceled
                };

                await this.repository.UpdateAsync(updateModel);
            }
        }

        private async Task<OrderGetAllByUserSPResult> GetOrderAsync(int userId, int medicationId, int pharmacyId)
        {
            var orders = await this.repository.GetAllByUserAsync(userId);
            return orders.FirstOrDefault(order => order.MedicationId == medicationId &&
                                                            order.PharmacyId == pharmacyId);
        }

        public async Task AcceptAsync(int orderId)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Status = OrderStatus.Accepted
            };

            await this.repository.UpdateAsync(updateModel);
        }

        public async Task CancelAsync(int orderId)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Status = OrderStatus.Canceled
            };

            await this.repository.UpdateAsync(updateModel);
        }

        public async Task NotifyPatientAsync(int orderId, double quantity)
        {
            var updateModel = new OrderUpdateSPParams()
            {
                Id = orderId,
                Available = quantity,
                Status = OrderStatus.Avaliable,
            };

            await this.repository.UpdateAsync(updateModel);
        }
    }
}
