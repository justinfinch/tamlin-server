using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;
using Nancy.Responses;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;
using Nancy.Owin;
using Nancy.Authentication.Forms;
using Tamlin.MCServer.Web.Security;

namespace Tamlin.MCServer.Web.Configuration
{
    internal class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(with => with.ViewLocationProvider = typeof(ResourceViewLocationProvider));
            }
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>(),
            };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            // Perform registration that should have an application lifetime
            var builder = new ContainerBuilder();

            builder.Update(existingContainer.ComponentRegistry);
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultUserMapper>().As<IUserMapper>().SingleInstance();

            builder.Register(ctx => 
            {
                var env = context.GetOwinEnvironment() ?? new Dictionary<string, object>();
                return new OwinContext(env);

            })
            .As<IOwinContext>()
            .SingleInstance();

            builder.Update(container.ComponentRegistry);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add((ctx, rootPath) =>
            {
                var path = Path.GetDirectoryName(ctx.Request.Url.Path) ?? string.Empty;
                const string resourcePath = @"\content";

                if (!path.StartsWith(resourcePath, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                var assembly = this.GetType().Assembly;
                var embededResourcePath = assembly.GetName().Name + Path.GetDirectoryName(ctx.Request.Path).Replace(Path.DirectorySeparatorChar, '.').Replace("-", "_");
                var embededResourceName = Path.GetFileName(ctx.Request.Path);

                return new EmbeddedFileResponse(assembly, embededResourcePath, embededResourceName);
            });
        }       
    }
}
