using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.DataStores.Models;

namespace MedProject.BusinessLogic.Mappers
{
    internal static class MedicationMapper
    {
        public static MedicationToOrderDto MapToDto(this GetMedicationsToOrderSPResult model)
        {
            return new MedicationToOrderDto()
            {
                PharmacyId = model.PharmacyId,
                Pharmacy = model.Pharmacy,
                MedicationId = model.MedicationId,
                Medication = model.Medication,
                Quantity = model.Quantity,
                OrderStatus = model.OrderStatus,
                Available = model.Available,
            };
        }
    }
}
