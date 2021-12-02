using MedProject.DataAccess.Enums;

namespace MedProject.DataAccess.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public MedUser User { get; set; }

        public Medication Medication { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public float Quantity { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public float Available { get; set; }
    }
}
