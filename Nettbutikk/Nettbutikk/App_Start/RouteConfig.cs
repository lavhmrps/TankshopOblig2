using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nettbutikk
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Account",
                url: "{controller}/{action?}",
                defaults: new {controller = "Accounts", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Products", action = "Index"}
            );
        }
    }
}
