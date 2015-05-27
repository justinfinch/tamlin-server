using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin;
using Nancy;
using Nancy.Owin;
using Nancy.Authentication.Forms;
using Tamlin.MCServer.Data.Users;
using Tamlin.MCServer.Web.Security;
using MCServer.Core.Logging.NLog;
using MCServer.Core.Logging;

namespace Tamlin.MCServer.Web.Configuration
{
    public class IoCPerRequestRegistrar : Module
    {
        private readonly NancyContext _context;

        public IoCPerRequestRegistrar(NancyContext context)
        {
            _context = context;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultUserMapper>().As<IUserMapper>().SingleInstance();
            builder.RegisterType<UserRepo>().As<IUserRepo>().SingleInstance();
            builder.RegisterType<NLogLogger>().As<ILogger>().SingleInstance();

            builder.Register(ctx =>
                {
                    var env = _context.GetOwinEnvironment() ?? new Dictionary<string, object>();
                    return new OwinContext(env);
                })
                .As<IOwinContext>()
                .SingleInstance();

            builder.Register(ctx =>
                {
                    return new SqlConnection(ConfigurationManager.ConnectionStrings["mcnfb"].ConnectionString);
                })
                .As<IDbConnection>()
                .SingleInstance();
        }
    }
}
