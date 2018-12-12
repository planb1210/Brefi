using Autofac;
using Brefi.WpfApplication.Data;
using Brefi.WpfApplication.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.WpfApplication
{
    public class Container
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Context>().AsSelf();

            builder.RegisterType<CatalogRepository>().AsSelf();
            builder.RegisterType<UpdateRepository>().AsSelf();
            builder.RegisterType<BrendRepository>().AsSelf();
            builder.RegisterType<EquipmentRepository>().AsSelf();
            builder.RegisterType<ToolTypeRepository>().AsSelf();

            var container = builder.Build();

            return container;
            /*
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
            builder.RegisterType<EquipmentService>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);/**/
        }
    }
}
