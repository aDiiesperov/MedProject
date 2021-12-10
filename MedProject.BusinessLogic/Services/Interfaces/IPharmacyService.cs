using MedProject.BusinessLogic.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services.Interfaces
{
    public interface IPharmacyService
    {
        Task<IList<PharmacyDto>> GetAssignedAsync(int userId);

        Task<IList<PharmacyDto>> GetListAsync();
    }
}
