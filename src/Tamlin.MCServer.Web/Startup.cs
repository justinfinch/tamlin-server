using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin;

using Nancy;
using Owin;
using Nancy.Owin;
using Tamlin.MCServer.Web.Configuration;

[assembly: OwinStartup(typeof(Tamlin.MCServer.Web.Startup))]

namespace Tamlin.MCServer.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(new NancyOptions()
            {
                Bootstrapper = new Bootstrapper()
            });
        }
    }
}
