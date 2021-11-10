using MedProject.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        protected abstract string nameGetProc { get; set; }

        public async Task<IList<T>> GetAllAsync()
        {
            return await AdoHelper.GetListByProcAsync<T>(this.nameGetProc);
        }
    }
}
