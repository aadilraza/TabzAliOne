﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolManagementSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DashboardV1", id = UrlParameter.Optional }
            );
        }
    }
}
