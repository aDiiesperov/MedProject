using Autofac;
using MedProject.BusinessLogic.Services;
using MedProject.BusinessLogic.Services.Interfaces;

namespace MedProject.BusinessLogic
{
    public static class Registrator
    {
        public static void Register(ContainerBuilder builder)
        {
            DataAccess.Registrator.Register(builder);
            builder.RegisterType<PharmacyService>().As<IPharmacyService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MedicationService>().As<IMedicationService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
        }
    }
}
