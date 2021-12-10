using MedProject.DataAccess.Enums;

namespace MedProject.DataAccess.DataStores.Models
{
    public class OrderUpdateSPParams
    {
        public int Id { get; set; }
        
        public double? Quantity { get; set; }

        public double? Available { get; set; }

        public OrderStatus? Status { get; set; }
    }
}
