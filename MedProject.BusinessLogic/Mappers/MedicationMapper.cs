using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Enums;
using MedProject.DataAccess.DataStores.Models;
using System;
using System.Linq;

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

        public static MedicationInfoDto MapToDto(this GetMedicationsInfoSPResult model)
        {
            return new MedicationInfoDto()
            {
                Pharmacy = model.Pharmacy,
                Medication = model.Medication,
                TotalQuantity = model.TotalQuantity,
                ItemOrders = model.ItemOrders.Select(io => io.MapToDto()),
            };
        }

        public static ItemOrderInfoDto MapToDto(this GetMedicationsInfoSPResult.ItemOrderSPResult model)
        {
            return new ItemOrderInfoDto()
            {
                Id = model.Id,
                OrderedQuantity = model.OrderedQuantity,
                UserName = model.UserName,
            };
        }
    }
}
