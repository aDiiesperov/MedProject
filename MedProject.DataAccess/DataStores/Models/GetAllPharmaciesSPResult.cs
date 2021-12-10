namespace MedProject.DataAccess.DataStores.Models
{
    public class GetAllPharmaciesSPResult
    {
        public class StateSPResult
        {
            public int Id { get; set; }

            public string Abbreviation { get; set; }

            public string Name { get; set; }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public StateSPResult State { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }
    }
}
