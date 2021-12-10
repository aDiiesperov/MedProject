using MedProject.DataAccess.DataStores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.Interfaces
{
    public interface IMedicationDataStore
    {
        Task<IList<GetMedicationsToOrderSPResult>> GetMedicationsToOrderAsync(int userId);

        Task<IList<GetMedicationsInfoSPResult>> GetMedicationsInfoAsync(byte requestedStatus);
    }
}
