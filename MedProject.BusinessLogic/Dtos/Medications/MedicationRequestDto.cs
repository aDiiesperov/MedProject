namespace MedProject.BusinessLogic.Dtos
{
    public class MedicationRequestDto
    {
        public int MedicationId { get; set; }

        public int PharmacyId { get; set; }

        public double Quantity { get; set; }
    }
}
