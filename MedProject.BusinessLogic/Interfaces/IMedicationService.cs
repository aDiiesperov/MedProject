using MedProject.BusinessLogic.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Interfaces
{
    public interface IMedicationService
    {
        Task<IList<MedicationToOrderDto>> GetMedicationsToOrderAsync(int userId);

        Task RequestMedicationsAsync(int userId, MedicationRequestDto request);
    }
}
