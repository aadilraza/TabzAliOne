using Autofac;
using Autofac.Integration.Mvc;
using SchoolManagementSystem.Web.App_Start.Modules;
using System.Reflection;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}