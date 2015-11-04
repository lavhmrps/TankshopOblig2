using Nettbutikk.Model;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nettbutikk
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TankshopDbContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperProfiles.Configure();
        }

        void Application_Error(object sender, EventArgs e)
        {

            Exception exception = Server.GetLastError();

            Logger.WriteToLog(exception);

            //TODO: Redirect to error page

        }
    }
}
