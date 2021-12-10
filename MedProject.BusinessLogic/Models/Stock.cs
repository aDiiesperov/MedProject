namespace MedProject.BusinessLogic.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public Medication Medication { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public float Quantity { get; set; }
    }
}
