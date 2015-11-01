using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Nettbutikk.Startup))]
namespace Nettbutikk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
