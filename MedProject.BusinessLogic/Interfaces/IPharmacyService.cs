using MedProject.BusinessLogic.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Interfaces
{
    public interface IPharmacyService : ICrudService<PharmacyDto>
    {
        Task<IList<PharmacyDto>> GetAssignedAsync(int userId);
    }
}
