using Autofac;
using MedProject.Services.Interfaces;
using MedProject.Services.Services;

namespace MedProject.Services
{
    public static class Registrator
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<AuthCacheManager>().SingleInstance();

            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}
