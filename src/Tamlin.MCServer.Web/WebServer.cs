using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCServer.Core.Logging;
using MCServer.Core.Logging.NLog;
using Microsoft.Owin.Hosting;
using Topshelf;

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

            StartWebServer();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _logger.Info("Shutting down web server");
            _webApp.Dispose();
            _logger.Info("Web server shut down");
            return true;
        }

        private void StartWebServer()
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://localhost:8080");
            startOptions.Urls.Add("http://127.0.0.1:8080");
            startOptions.Urls.Add("http://192.168.1.70:8080");

            _webApp = WebApp.Start<Startup>(startOptions);
            _logger.Info("Web server started");
            
        }
    }
}
