using System.Data;
using System.Data.SqlClient;

namespace MedProject.DataAccess.DataStores.AdoUtils
{
    internal class AdoSPBuilder
    {
        private readonly SqlCommand cmd;

        public AdoSPBuilder(string connectionString, string procName)
        {
            var connection = new SqlConnection(connectionString);
            this.cmd = new SqlCommand(procName, connection);
            this.cmd.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameter(string parameterName, object value)
        {
            this.cmd.Parameters.AddWithValue(parameterName, value);
        }

        // TODO: add other params (out)

        public AdoSPExecutor Build()
        {
            return new AdoSPExecutor(cmd);
        }
    }
}
