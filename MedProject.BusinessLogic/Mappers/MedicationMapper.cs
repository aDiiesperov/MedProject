using MedProject.BusinessLogic.Dtos;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Enums;
using System;

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
                TotalQuantity = model.TotalQuantity,
                Status = model.Status.HasValue ? Enum.GetName(typeof(OrderStatus), model.Status) : null,
                OrderedQuantity = model.OrderedQuantity,
                Available = model.Available,
            };
        }
    }
}
