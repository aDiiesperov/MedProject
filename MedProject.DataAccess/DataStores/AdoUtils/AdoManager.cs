using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.AdoUtils
{
    internal sealed class AdoManager
    {
        private readonly string connectionString;

        public AdoManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // TODO: add transactions in the future
        public AdoSPBuilder CreateSPBuilder(string procName)
        {
            return new AdoSPBuilder(this.connectionString, procName);
        }

        public async Task<IList<T>> GetAllByProcAsync<T>(string procName)
            where T : class
        {
            var builder = new AdoSPBuilder(this.connectionString, procName);
            using(var executor = builder.Build())
            {
                return await executor.ReadAllAsync<T>();
            }
        }

        public async Task<T> GetByProcAsync<T>(string procName, int id)
            where T : class
        {
            var builder = new AdoSPBuilder(this.connectionString, procName);
            builder.AddParameter("@id", id);

            using (var executor = builder.Build())
            {
                return await executor.ReadFirstAsync<T>();
            }
        }
    }
}
