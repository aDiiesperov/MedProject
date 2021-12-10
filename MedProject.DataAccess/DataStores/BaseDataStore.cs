using MedProject.DataAccess.DataStores.AdoUtils;

namespace MedProject.DataAccess.DataStores
{
    internal abstract class BaseDataStore
    {
        protected readonly AdoManager adoManager;

        public BaseDataStore(AdoManager adoManager)
        {
            this.adoManager = adoManager;
        }
    }
}
