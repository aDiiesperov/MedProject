using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.BusinessLogic.Mappers;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services
{
    internal class UserService : CrudService<MedUserDto, MedUser, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public async Task<IList<PatientDto>> GetPatientListAsync()
        {
            var list = await this.repository.GetByRoleAsync("Patient");
            return list.Select(i => i.MapToDto()).ToList();
        }

        protected override MedUserDto MapToDto(MedUser model)
        {
            return model.MapToDto();
        }
    }
}
