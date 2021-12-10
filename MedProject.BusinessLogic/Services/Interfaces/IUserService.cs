using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<PatientDto>> GetPatientListAsync();

        Task<MedUser> GetByLoginAsync(string loginName);
    }
}
