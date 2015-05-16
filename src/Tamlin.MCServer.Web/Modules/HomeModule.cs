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
                dynamic test = new ExpandoObject();
                test.Name = "Justin";
                test.Last = "finch";
                return View["index", test];
            };
        }
    }
}
