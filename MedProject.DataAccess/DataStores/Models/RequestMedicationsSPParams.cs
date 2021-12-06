using MedProject.DataAccess.Enums;

namespace MedProject.DataAccess.DataStores.Models
{
    public class RequestMedicationsSPParams
    {
        public int UserId { get; set; }

        public int MedicationId { get; set; }
        
        public int PharmacyId { get; set; }
        
        public double Quantity { get; set; }

        public OrderStatus Status { get; set; }
    }
}
