using System.Collections.Generic;

namespace MedProject.BusinessLogic.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateAbbreviation { get; set; }

        public IList<PatientPharmacyDto> Pharmacies { get; set; }
    }
}
