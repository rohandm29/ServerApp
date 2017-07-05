using System.Web.Http;
using Autofac.Integration.WebApi;
using Kalingo.WebApi.Startup;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Kalingo.WebApi.Startup
{
    public class Startup
    { 
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);

            var container = ContainerConfig.ConfigureAndBuildContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}