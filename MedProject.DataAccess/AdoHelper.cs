using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MedProject.DataAccess
{
    internal class AdoHelper
    {
        private string ConnectionString { get; set; }

        public AdoHelper()
        {
            // TODO: take out name to IoC string ('Default')
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public async Task<IList<T>> GetListByProcAsync<T>(string procName)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    var reader = await cmd.ExecuteReaderAsync();
                    return await this.ReadData<T>(reader);
                }
            }
        }

        private async Task<IList<T>> ReadData<T>(SqlDataReader reader)
        {
            var res = new List<T>();

            if (!reader.HasRows)
            {
                return res;
            }

            var props = typeof(T).GetProperties();


            while (await reader.ReadAsync())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in props)
                {
                    prop.SetValue(obj, reader[prop.Name]);
                }
                res.Add(obj);
            }

            return res;
        }
    }
}
