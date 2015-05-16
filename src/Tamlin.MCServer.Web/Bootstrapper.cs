using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;
using Nancy.Responses;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Tamlin.MCServer.Web
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(with => with.ViewLocationProvider = typeof(ResourceViewLocationProvider));
            }
        }

        //protected override ILifetimeScope GetApplicationContainer()
        //{
        //    // Return application container instance
        //}

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            //ResourceViewLocationProvider
            //    .RootNamespaces
            //    .Add(GetType().Assembly, "Tamlin.MCServer.Web.Views");
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
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
