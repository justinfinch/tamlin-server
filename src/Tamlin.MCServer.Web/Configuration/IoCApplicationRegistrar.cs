using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Tamlin.MCServer.Business.Security;

namespace Tamlin.MCServer.Web.Configuration
{
    public class IoCApplicationRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryUserCache>().As<IUserCache>().SingleInstance();
        }
    }
}
