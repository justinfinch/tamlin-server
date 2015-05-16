using System;
using System.Threading.Tasks;
using Autofac;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Owin;
using BrockAllen.MembershipReboot.Relational;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Nancy;
using Owin;
using Tamlin.MembershipReboot;
using Nancy.Owin;
using Tamlin.MCServer.Web.Configuration;

[assembly: OwinStartup(typeof(Tamlin.MCServer.Web.Startup))]

namespace Tamlin.MCServer.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login")
            };

            app.UseMembershipReboot(cookieOptions);

            app.UseNancy(new NancyOptions()
            {
                Bootstrapper = new Bootstrapper(MembershipRebootConfig.Create(app))
            });
        }
    }
}
