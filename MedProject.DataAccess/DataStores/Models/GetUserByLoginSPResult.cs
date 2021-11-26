using System.Collections.Generic;

namespace MedProject.DataAccess.DataStores.Models
{
    public class GetUserByLoginSPResult
    {
        public class RoleSPResult
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string PasswordHash { get; set; }

        public IList<RoleSPResult> Roles { get; set; }
    }
}
