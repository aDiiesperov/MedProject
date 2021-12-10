using MedProject.BusinessLogic.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Services.Interfaces
{
    public interface IMedicationService
    {
        Task<IList<MedicationToOrderDto>> GetMedicationsToOrderAsync(int userId);

        Task<IList<MedicationInfoDto>> GetMedicationsInfoAsync();
    }
}
