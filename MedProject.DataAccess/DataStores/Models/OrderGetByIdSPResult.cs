namespace MedProject.DataAccess.DataStores.Models
{
    public class OrderGetByIdSPResult
    {
        public double Quantity { get; set; }

        public byte Status { get; set; }

        public double? Available { get; set; }
    }
}
