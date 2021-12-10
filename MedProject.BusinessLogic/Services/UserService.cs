using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Services.Interfaces;
using MedProject.BusinessLogic.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedProject.BusinessLogic.Models;
using MedProject.DataAccess.DataStores.Interfaces;

namespace MedProject.BusinessLogic.Services
{
    internal class UserService : BaseService<IUserDataStore>, IUserService
    {
        public UserService(IUserDataStore store) : base(store)
        {
        }

        public async Task<MedUser> GetByLoginAsync(string loginName)
        {
            var user = await this.store.GetByLoginAsync(loginName);
            return user.MapToEntity();
        }

        public async Task<IList<PatientDto>> GetPatientListAsync()
        {
            var list = await this.store.GetByRoleAsync("Patient");
            return list.Select(i => i.MapToDto()).ToList();
        }
    }
}
