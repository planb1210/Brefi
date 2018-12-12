using Autofac;
using Autofac.Integration.WebApi;
using Brefi.Data;
using Brefi.Data.Repositories;
using Brefi.Services;
using System.Reflection;
using System.Web.Http;

namespace Brefi.WebApi.App_Start
{
    public class Container
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<BrefiContext>().AsSelf();
            builder.RegisterType<EquipmentRepository>().AsSelf();
            builder.RegisterType<ToolTypeRepository>().AsSelf();
            builder.RegisterType<BrendRepository>().AsSelf();
            builder.RegisterType<CatalogService>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}