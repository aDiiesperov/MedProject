using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Mapper;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal class UserRepository : Repository<MedUser, UserDataStore>, IUserRepository
    {
        public UserRepository(UserDataStore store) : base(store)
        {
        }

        public async Task<MedUser> GetByLoginAsync(string loginName)
        {
            var res = await this.store.GetByLoginAsync(loginName);
            return res.MapToEntity();
        }

        public Task<IList<GetUsersByRoleSPResult>> GetByRoleAsync(string role)
        {
            return this.store.GetByRoleAsync(role);
        }
    }
}
