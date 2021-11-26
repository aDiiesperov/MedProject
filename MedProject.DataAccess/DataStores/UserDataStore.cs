using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class UserDataStore : BaseDataStore<MedUser>
    {
        public UserDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public override Task<IList<MedUser>> GetAllAsync()
        {
            return this.adoManager.GetAllByProcAsync<MedUser>("GetAllMedUsers");
        }

        public async Task<IList<GetUsersByRoleSPResult>> GetByRoleAsync(string role)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetUsersByRole");

                spBuilder.AddParameter("@role", role);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadAllAsync<GetUsersByRoleSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetUserByLoginSPResult> GetByLoginAsync(string loginName)
        {
            try
            {
                var spBuilder = adoManager.CreateSPBuilder("GetUserByLogin");

                spBuilder.AddParameter("@loginName", loginName);

                using (var executor = spBuilder.Build())
                {
                    return await executor.ReadFirstAsync<GetUserByLoginSPResult>();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
