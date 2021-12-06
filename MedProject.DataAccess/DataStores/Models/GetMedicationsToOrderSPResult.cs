using MedProject.DataAccess.Enums;

namespace MedProject.DataAccess.DataStores.Models
{
    public class GetMedicationsToOrderSPResult
    {
        public int PharmacyId { get; set; }

        public string Pharmacy { get; set; }

        public int MedicationId { get; set; }

        public string Medication { get; set; }

        public double TotalQuantity { get; set; }

        public byte? Status { get; set; }

        public double OrderedQuantity { get; set; }

        public double? Available { get; set; }
    }
}
