using Autofac;
using SchoolManagementSystem.Data.Repository.Implementations;
using System.Linq;

namespace SchoolManagementSystem.Web.App_Start.Modules
{
    public class RepositoryModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(StudentRepository).Assembly)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}