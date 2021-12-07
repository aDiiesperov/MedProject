using MedProject.DataAccess.DataStores.Models;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Interfaces
{
    public interface IMedicationRepository : IRepository<Medication>
    {
        Task<IList<GetMedicationsToOrderSPResult>> GetMedicationsToOrderAsync(int userId);

        Task RequestMedicationsAsync(RequestMedicationsSPParams sPParams);

        Task CancelMedicationsAsync(CancelMedicationsSPParams sPParams);
    }
}
