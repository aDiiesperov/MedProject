namespace MedProject.DataAccess.DataStores.Models
{
    public class OrderGetAllByUserSPResult
    {
        public int Id { get; set; }

        public int MedicationId { get; set; }

        public int PharmacyId { get; set; }

        public double Quantity { get; set; }

        public byte Status { get; set; }

        public double? Available { get; set; }
    }
}
