using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MedProject.DataAccess
{
    internal static class AdoHelper
    {
        private static string ConnectionString { get; set; }

        static AdoHelper()
        {
            // TODO: take out name to IoC string ('Default')
            AdoHelper.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public static async Task<IList<T>> GetListByProcAsync<T>(string procName)
        {
            using (SqlConnection con = new SqlConnection(AdoHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    var reader = await cmd.ExecuteReaderAsync();
                    return await AdoHelper.ReadData<T>(reader);
                }
            }
        }

        private static async Task<IList<T>> ReadData<T>(SqlDataReader reader)
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
