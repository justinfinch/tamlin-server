using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCServer.Core.Logging;
using Nancy;
using Nancy.Security;

namespace Tamlin.MCServer.Web.Modules
{
    public class ShopFloorModule : NancyModule
    {
        public ShopFloorModule(ILogger logger)
        {
            this.RequiresAuthentication();

            Get["/ShopFloor"] = parameters =>
            {
                logger.Info("You have loaded Shop Floor.");

                var user = this.Context.CurrentUser;
                dynamic test = new ExpandoObject();
                test.Name = user.UserName;
                return View["index", test];
            };
        }
    }
}
