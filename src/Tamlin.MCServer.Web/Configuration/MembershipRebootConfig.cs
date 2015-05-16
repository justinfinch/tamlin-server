using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Owin;
using Owin;

namespace Tamlin.MCServer.Web.Configuration
{
    public static class MembershipRebootConfig
    {
        public static MembershipRebootConfiguration Create(IAppBuilder app)
        {
            var config = new MembershipRebootConfiguration();
            config.RequireAccountVerification = false;
            config.AddEventHandler(new DebuggerEventHandler());

            var appInfo = new OwinApplicationInformation(
                app,
                "MC",
                "Thank you",
                "/Login",
                "/ChangeEmail/Confirm/",
                "/Register/Cancel/",
                "/PasswordReset/Confirm/");

            var emailFormatter = new EmailMessageFormatter(appInfo);
            // uncomment if you want email notifications -- also update smtp settings in web.config
            config.AddEventHandler(new EmailAccountEventsHandler(emailFormatter));
            // uncomment to enable SMS notifications -- also update TwilloSmsEventHandler class below
            //config.AddEventHandler(new TwilloSmsEventHandler(appinfo));

            // uncomment to ensure proper password complexity
            //config.ConfigurePasswordComplexity();

            return config;
        }
    }
}
