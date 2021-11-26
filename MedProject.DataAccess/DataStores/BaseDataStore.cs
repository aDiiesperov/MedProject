using MedProject.DataAccess.DataStores.AdoUtils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores
{
    internal abstract class BaseDataStore<TModel> where TModel : class
    {
        protected readonly AdoManager adoManager;

        public BaseDataStore(AdoManager adoManager)
        {
            this.adoManager = adoManager;
        }

        public abstract Task<IList<TModel>> GetAllAsync();
    }
}
