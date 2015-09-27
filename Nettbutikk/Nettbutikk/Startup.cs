using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;
using Nettbutikk.DAL;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;

[assembly: OwinStartup(typeof(Nettbutikk.Infrastructure.Startup))]

namespace Nettbutikk.Infrastructure
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOAuthTokenGeneration(app);

            ConfigureWebApi(httpConfig);

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);

        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(NettbutikkContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
