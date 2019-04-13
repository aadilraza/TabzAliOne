using SchoolManagementSystem.Data;
using SchoolManagementSystem.Web;
using SchoolManagementSystem.Web.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchoolManagementSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.ConfigureContainer();
            AutoMapperConfig.Configure();

            //Database Initialization
            Database.SetInitializer(new SchoolInitializer());

            // Register custom flag enum model binder
            ModelBinders.Binders.DefaultBinder = new FlagEnumModelBinder();
        }
    }
}
