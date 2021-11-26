using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;

namespace MedProject.DataAccess.Repositories
{
    internal class PharmacyRepository : Repository<Pharmacy, PharmacyDataStore>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDataStore store) : base(store)
        {
        }
    }
}
