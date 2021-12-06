using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.BusinessLogic.Mappers;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Enums;
using MedProject.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository repository;

        public MedicationService(IMedicationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<MedicationToOrderDto>> GetMedicationsToOrderAsync(int userId)
        {
            var list = await this.repository.GetMedicationsToOrderAsync(userId);
            return list.Select(i => i.MapToDto()).ToList();
        }

        public async Task RequestMedicationsAsync(int userId, MedicationRequestDto request)
        {
            var model = new RequestMedicationsSPParams()
            {
                UserId = userId,
                MedicationId = request.MedicationId,
                PharmacyId = request.PharmacyId,
                Quantity = request.Quantity,
                Status = OrderStatus.Requested,
            };

            await this.repository.RequestMedicationsAsync(model);
        }
    }
}
