using System.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Kalingo.WebApi.Startup;
using Owin;

namespace Kalingo.WebApi.AcceptanceTests.WebApi.Support
{
    public class OwinTestConf
    {
        public IContainer Container { get; set; }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);

            var builder = ContainerConfig.Configure();
            ConfigureTestContainer(builder);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        public void ConfigureTestContainer(ContainerBuilder apiBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KalingoDB"].ConnectionString;

            var builder = apiBuilder ?? new ContainerBuilder();

            builder.RegisterType<DbHelper>().WithParameter("connectionString", connectionString);

            Container = builder.Build();
        }
    }
}
