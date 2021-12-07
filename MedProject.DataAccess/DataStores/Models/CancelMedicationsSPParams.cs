using MedProject.DataAccess.Enums;

namespace MedProject.DataAccess.DataStores.Models
{
    public class CancelMedicationsSPParams
    {
        public int UserId { get; set; }

        public int MedicationId { get; set; }

        public int PharmacyId { get; set; }

        public OrderStatus Status { get; set; }
    }
}
