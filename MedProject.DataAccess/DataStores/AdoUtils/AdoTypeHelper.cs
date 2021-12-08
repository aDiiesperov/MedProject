using System;
using System.Collections.Generic;
using System.Linq;

namespace MedProject.DataAccess.DataStores.AdoUtils
{
    internal static class AdoTypeHelper
    {
        public static bool IsClass(this Type propertyType)
        {
            return propertyType.IsClass && !(propertyType.IsAssignableFrom(typeof(string)));
        }

        public static bool IsGenericCollection(this Type propertyType)
        {
            var isEnumerable = propertyType.IsGenericEnumerable() ||
                propertyType.GetInterfaces().Any(t => t.IsGenericEnumerable());

            var isString = propertyType.IsAssignableFrom(typeof(string));

            return isEnumerable && !isString;
        }

        private static bool IsGenericEnumerable(this Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}
