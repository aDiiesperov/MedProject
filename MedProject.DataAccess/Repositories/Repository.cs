using MedProject.DataAccess.DataStores;
using MedProject.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal abstract class Repository<TModel, TStore> : IRepository<TModel> 
        where TModel : class
        where TStore : BaseDataStore<TModel>
    {
        protected readonly TStore store;

        public Repository(TStore store)
        {
            this.store = store;
        }

        public Task<IList<TModel>> GetAllAsync()
        {
            return this.store.GetAllAsync();
        }
    }
}
