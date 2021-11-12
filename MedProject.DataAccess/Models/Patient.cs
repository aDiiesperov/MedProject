using System;

namespace MedProject.DataAccess.Models
{
    public class Patient
    {
        public int Id { get; set; }

	    public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateCode { get; set; }

        public string PharmacyName { get; set; }

	    public DateTime PharmacyAssignDate { get; set; }


    }
}
