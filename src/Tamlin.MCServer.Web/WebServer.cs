using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MCServer.Core.Logging;
using MCServer.Core.Logging.NLog;
using Microsoft.Owin.Hosting;
using Topshelf;
using System.Linq;
using System.Net.Sockets;

namespace Tamlin.MCServer.Web
{
    public class WebServer : ServiceControl
    {
        private ILogger _logger;
        private IDisposable _webApp;

        public WebServer()
        {
            _logger = new NLogLogger();
        }

        public bool Start(HostControl hostControl)
        {
            _logger.Info("Web Server starting");

            StartWebServer(8080);

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _logger.Info("Shutting down web server");
            _webApp.Dispose();
            _logger.Info("Web server shut down");
            return true;
        }

        private void StartWebServer(int port)
        {
            var httpUrlFormat = "http://{0}:{1}";
            var startOptions = new StartOptions();
            //TODO: Add port and host headers to configuration
            startOptions.Urls.Add(String.Format(httpUrlFormat, "localhost", port));
            startOptions.Urls.Add(String.Format(httpUrlFormat, Environment.MachineName, port));

            var ipHostHeaders = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .Select(ip => String.Format(httpUrlFormat, ip.ToString(), port));

            foreach(var ipHostHeader in ipHostHeaders)
            {
                startOptions.Urls.Add(ipHostHeader);
            }
            
            _webApp = WebApp.Start<Startup>(startOptions);

            _logger.Info("Web server started");
            foreach(var url in startOptions.Urls)
            {
                _logger.Info(string.Format("Web server listening on => {0}", url));
            }
            
        }
    }
}
