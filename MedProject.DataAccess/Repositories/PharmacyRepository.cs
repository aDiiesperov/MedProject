using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal class PharmacyRepository : Repository<Pharmacy, PharmacyDataStore>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDataStore store) : base(store)
        {
        }

        public Task<IList<Pharmacy>> GetAssignedAsync(int userId)
        {
            return this.store.GetAssignedAsync(userId);
        }
    }
}
