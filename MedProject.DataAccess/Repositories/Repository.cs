using MedProject.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly AdoHelper adoHelper;

        protected abstract string nameGetProc { get; set; }

        public Repository(AdoHelper adoHelper)
        {
            this.adoHelper = adoHelper;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await this.adoHelper.GetListByProcAsync<T>(this.nameGetProc);
        }
    }
}
