using System;
using System.Collections.Generic;

namespace MedProject.DataAccess.DataStores.Models
{
    public class GetUsersByRoleSPResult
    {
        public class PharmacySPResult
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime AssignDate { get; set; }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateAbbreviation { get; set; }

        public IList<PharmacySPResult> Pharmacies { get; set; }
    }
}
