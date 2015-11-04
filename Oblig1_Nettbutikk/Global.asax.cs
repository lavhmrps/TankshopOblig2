using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Oblig1_Nettbutikk
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
                        
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TankshopDbContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {

            Exception exception = Server.GetLastError();
            Logging.LogHandler.WriteToLog(exception);

            //TODO: Redirect to error page

        }

    }
}
