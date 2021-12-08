using System.Collections.Generic;

namespace MedProject.BusinessLogic.Dtos
{
    public class MedicationInfoDto
    {
        public string Pharmacy { get; set; }

        public string Medication { get; set; }

        public double TotalQuantity { get; set; }

        public IEnumerable<ItemOrderInfoDto> ItemOrders { get; set; }
    }
}
