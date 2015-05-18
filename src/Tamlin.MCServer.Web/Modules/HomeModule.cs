using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Security;

namespace Tamlin.MCServer.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.RequiresAuthentication();

            Get["/"] = parameters =>
            {
                var user = this.Context.CurrentUser;

                dynamic test = new ExpandoObject();
                test.Name = user.UserName;
                return View["index", test];
            };
        }
    }
}
