using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamlin.MCServer.Web;
using Topshelf;

namespace Tamlin.MCServer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configurator =>
            {
                configurator.Service<WebServer>();

                configurator.SetDisplayName("Tamlin MC Server");
                configurator.SetDescription("Tamlin MC Server");

                configurator.RunAsNetworkService();
            });
        }
    }
}
