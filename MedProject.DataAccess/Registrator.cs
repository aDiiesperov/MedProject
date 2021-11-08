using Autofac;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Repositories;

namespace MedProject.DataAccess
{
    public static class Registrator
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<PharmacyRepository>().As<IPharmacyRepository>();
            builder.RegisterType<AdoHelper>();
        }
    }
}
