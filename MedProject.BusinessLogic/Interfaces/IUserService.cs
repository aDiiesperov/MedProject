using MedProject.BusinessLogic.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Interfaces
{
    public interface IUserService : ICrudService<MedUserDto>
    {
        Task<IList<PatientDto>> GetPatientListAsync();
    }
}
