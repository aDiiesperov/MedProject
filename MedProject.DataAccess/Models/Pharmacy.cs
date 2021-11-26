namespace MedProject.DataAccess.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public State State { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }
    }
}
