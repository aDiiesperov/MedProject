using MedProject.BusinessLogic.Enums;

namespace MedProject.BusinessLogic.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public MedUser User { get; set; }

        public Medication Medication { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public double Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public double? Available { get; set; }
    }
}
