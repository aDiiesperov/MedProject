using System.Collections.Generic;

namespace MedProject.DataAccess.DataStores.Models
{
    public class GetAllMedUsersSPResult
    {
        public class StateSPResult
        {
            public int Id { get; set; }

            public string Abbreviation { get; set; }

            public string Name { get; set; }
        }

        public class MedRole
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class Pharmacy
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public StateSPResult State { get; set; }

            public string Address { get; set; }

            public string Email { get; set; }

            public long Phone { get; set; }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string PasswordHash { get; set; }

        public StateSPResult State { get; set; }

        public IList<MedRole> Roles { get; set; }

        public IList<Pharmacy> Pharmacies { get; set; }

        public GetAllMedUsersSPResult()
        {
            this.Roles = new List<MedRole>();
            this.Pharmacies = new List<Pharmacy>();
        }
    }
}
