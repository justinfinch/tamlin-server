using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot;
using Nancy;

namespace Tamlin.MCServer.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(AuthenticationService authService) : base("/login")
        {
            var userAccountService = authService.UserAccountService;

            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}
