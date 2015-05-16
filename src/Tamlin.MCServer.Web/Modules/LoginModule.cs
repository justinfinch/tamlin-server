using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace Tamlin.MCServer.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule() : base("/login")
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}
