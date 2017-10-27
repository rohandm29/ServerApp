using System.IdentityModel.Tokens;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Kalingo.WebApi.Startup;
using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Kalingo.WebApi.Startup
{
    public class Startup
    { 
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Auth.ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseWebApi(config);

            var container = ContainerConfig.ConfigureAndBuildContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}