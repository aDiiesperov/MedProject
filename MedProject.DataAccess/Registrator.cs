using Autofac;
using MedProject.DataAccess.DataStores.AdoUtils;
using System.Configuration;
using System.Reflection;

namespace MedProject.DataAccess
{
    public static class Registrator
    {
        public static void Register(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            builder.Register(c => new AdoManager(connectionString)).AsSelf();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("DataStore") && !t.IsAbstract)
                .AsImplementedInterfaces();
        }
    }
}
