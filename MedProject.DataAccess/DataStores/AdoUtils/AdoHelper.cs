using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Reflection;
using MedProject.DataAccess.DataStores.AdoUtils;

namespace MedProject.DataAccess
{
    // TODO: it needs to refacoring
    internal static class AdoHelper
    {

        public static async Task<IList<T>> ReadData<T>(SqlDataReader reader)
            where T : class
        {
            var list = new List<T>();

            if (!reader.HasRows)
            {
                return list;
            }

            while (await reader.ReadAsync())
            {
                if (!AdoHelper.TryGetExistsObject(list, reader, out var obj))
                {
                    obj = Activator.CreateInstance<T>();
                    list.Add(obj as T);
                }

                AdoHelper.PopulateObject(obj, reader);
            }

            reader.Close();

            return list;
        }

        private static void PopulateObject(object obj, SqlDataReader reader, string tablePrefix = "")
        {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;

                if (propType.IsEnumerable())
                {
                    AdoHelper.PopulateEnumerable(obj, prop, reader, tablePrefix);
                }
                else if (propType.IsNavigationClass())
                {
                    AdoHelper.PopulateClass(obj, prop, reader, tablePrefix);
                }
                else
                {
                    var val = reader[tablePrefix + prop.Name];
                    prop.SetValue(obj, val is DBNull ? null : val);
                }
            }
        }

        private static void PopulateEnumerable(object obj, PropertyInfo prop, SqlDataReader reader, string tablePrefix)
        {
            var itemType = prop.PropertyType.GetGenericArguments().Single();
            var list = prop.GetValue(obj);
            if (list == null)
            {
                var listType = typeof(List<>).MakeGenericType(itemType);
                list = Activator.CreateInstance(listType);
                prop.SetValue(obj, list);
            }

            if (!AdoHelper.TryGetExistsObject(list as IEnumerable, reader, out object itemObj, tablePrefix + prop.Name))
            {
                if (!AdoHelper.TryCreateInstance(itemType, reader, tablePrefix + prop.Name, out itemObj))
                {
                    return;
                }

                var addMethod = list.GetType().GetMethod("Add");
                addMethod.Invoke(list, new[] { itemObj });
            }

            AdoHelper.PopulateObject(itemObj, reader, tablePrefix + prop.Name);
        }

        private static void PopulateClass(object obj, PropertyInfo prop, SqlDataReader reader, string tablePrefix)
        {
            var item = prop.GetValue(obj);
            if (item == null)
            {
                if (!AdoHelper.TryCreateInstance(prop.PropertyType, reader, tablePrefix + prop.Name, out item))
                {
                    return;
                }

                prop.SetValue(obj, item);
            }

            AdoHelper.PopulateObject(item, reader, tablePrefix + prop.Name);
        }

        private static bool TryGetExistsObject(IEnumerable list, SqlDataReader reader, out object obj, string tablePrefix = "")
        {
            var itemType = list.GetType().GetGenericArguments().Single();
            var itemProps = itemType.GetProperties()
                                .Where(p => !p.PropertyType.IsEnumerable() && !p.PropertyType.IsNavigationClass());

            foreach (var item in list)
            {
                if (itemProps.All(prop => prop.GetValue(item).Equals(reader[tablePrefix + prop.Name])))
                {
                    obj = item;
                    return true;
                }
            }

            obj = null;
            return false;
        }

        private static bool TryCreateInstance(Type itemType, SqlDataReader reader, string tablePrefix, out object instance)
        {
            instance = reader[tablePrefix + "Id"] is DBNull
                        ? null
                        : Activator.CreateInstance(itemType);

            return instance != null;
        }
    }
}
