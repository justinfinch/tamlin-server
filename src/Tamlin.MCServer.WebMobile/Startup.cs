using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamlin.MCServer.WebMobile.Startup))]
namespace Tamlin.MCServer.WebMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
