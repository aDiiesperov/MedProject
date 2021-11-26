using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MedProject.DataAccess.DataStores.AdoUtils
{
    internal static class AdoTypeHelper
    {
        public static bool IsNavigationClass(this Type propertyType)
        {
            return propertyType.IsClass && !(propertyType.IsAssignableFrom(typeof(string)));
        }

        public static bool IsEnumerable(this Type propertyType)
        {
            var isEnumerable = propertyType.GetInterfaces()
                .Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            var isString = propertyType.IsAssignableFrom(typeof(string));

            return isEnumerable && !isString;
        }
    }
}
