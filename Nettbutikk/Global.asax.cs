using Nettbutikk.Model;
using System;
using System.Data.Entity;
using System.IO;
using System.Web;
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
            InitializeLogger();
        }

        private void InitializeLogger()
        {
            var folder = HttpContext.Current.Server.MapPath(Logger.LOG_PATH);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            Logger.Initialize(folder);
        }

        void Application_Error(object sender, EventArgs e)
        {

            Exception exception = Server.GetLastError();

            Logger.WriteToLog(exception);

            //TODO: Redirect to error page

        }
    }
}
