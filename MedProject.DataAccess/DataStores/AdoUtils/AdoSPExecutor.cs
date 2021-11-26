using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MedProject.DataAccess.DataStores.AdoUtils
{
    internal class AdoSPExecutor : IDisposable
    {
        private SqlCommand cmd;

        private bool _disposedValue;

        public AdoSPExecutor(SqlCommand cmd)
        {
            this.cmd = cmd;
        }

        public async Task<T> ReadFirstAsync<T>()
            where T : class
        {
            var list = await this.ReadAllAsync<T>();
            return list.FirstOrDefault();
        }

        public async Task<IList<T>> ReadAllAsync<T>()
            where T : class
        {
            this.OpenConnection();
            var reader = await this.cmd.ExecuteReaderAsync();
            return await AdoHelper.ReadData<T>(reader);
        }

        private void OpenConnection()
        {
            if (this.cmd.Connection.State != ConnectionState.Open)
            {
                this.cmd.Connection.Open();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AdoSPExecutor() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {

                if (this.cmd.Connection.State == ConnectionState.Open)
                {
                    this.cmd.Connection.Close();
                    this.cmd.Clone();
                }

                _disposedValue = true;
            }
        }
    }
}
