using System;

namespace MedProject.BusinessLogic.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateCode { get; set; }

        public string PharmacyName { get; set; }

        public DateTime PharmacyAssignDate { get; set; }
    }
}
