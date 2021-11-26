using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace MedProject.Web
{
    public class ContainerConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Register DataAccess services
            BusinessLogic.Registrator.Register(builder);
            Services.Registrator.Register(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}