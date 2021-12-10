using MedProject.DataAccess.DataStores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.Interfaces
{
    public interface IUserDataStore
    {
        Task<IList<GetAllMedUsersSPResult>> GetAllAsync();

        Task<IList<GetUsersByRoleSPResult>> GetByRoleAsync(string role);

        Task<GetUserByLoginSPResult> GetByLoginAsync(string loginName);
    }
}
