using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nettbutikk.Startup))]
namespace Nettbutikk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
