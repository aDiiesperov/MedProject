using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<MedUser>
    {
        Task<MedUser> GetByLoginAsync(string loginName);

        Task<IList<GetUsersByRoleSPResult>> GetByRoleAsync(string role);
    }
}
