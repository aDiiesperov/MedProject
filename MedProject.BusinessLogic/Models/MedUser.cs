using System.Collections.Generic;

namespace MedProject.BusinessLogic.Models
{
    public class MedUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string PasswordHash { get; set; }

        public State State { get; set; }

        public IList<MedRole> Roles { get; set; }

        public IList<Pharmacy> Pharmacies { get; set; }

        public MedUser()
        {
            this.Roles = new List<MedRole>();
            this.Pharmacies = new List<Pharmacy>();
        }
    }
}
