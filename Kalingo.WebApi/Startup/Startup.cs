using System.Configuration;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Kalingo.WebApi.Middleware;
using Kalingo.WebApi.Startup;
using Microsoft.Azure;
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

            if(bool.Parse(CloudConfigurationManager.GetSetting("AuthEnabled")))
                app.Use(typeof(AuthMiddleware));

            WebApiConfig.Register(config);

            app.UseWebApi(config);

            var container = ContainerConfig.ConfigureAndBuildContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}