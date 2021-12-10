namespace MedProject.DataAccess.DataStores.Models
{
    public class OrderUpdateSPParams
    {
        public int Id { get; set; }
        
        public double? Quantity { get; set; }

        public double? Available { get; set; }

        public byte? Status { get; set; }
    }
}
