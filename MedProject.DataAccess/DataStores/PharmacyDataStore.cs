using MedProject.DataAccess.DataStores.AdoUtils;
using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal class PharmacyDataStore : BaseDataStore<Pharmacy>
    {
        public PharmacyDataStore(AdoManager adoManager) : base(adoManager)
        {
        }

        public override Task<IList<Pharmacy>> GetAllAsync()
        {
            return this.adoManager.GetAllByProcAsync<Pharmacy>("GetAllPharmacies");
        }
    }
}
