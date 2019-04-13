using Autofac;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Infrastructure.Implementations;
using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using System.Data.Entity;

namespace SchoolManagementSystem.Web.App_Start.Modules
{
    public class EFModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterType(typeof(SchoolEntities)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}