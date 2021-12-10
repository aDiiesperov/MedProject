using MedProject.DataAccess.DataStores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.Interfaces
{
    public interface IPharmacyDataStore
    {
        Task<IList<GetAllPharmaciesSPResult>> GetAllAsync();

        Task<IList<GetAllPharmaciesSPResult>> GetAssignedAsync(int userId);
    }
}
