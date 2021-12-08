using System.Collections.Generic;

namespace MedProject.BusinessLogic.Dtos
{
    public class MedUserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StateCode { get; set; }

        public IList<MedRoleDto> Roles { get; set; }
    }
}
