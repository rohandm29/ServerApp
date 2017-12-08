using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Kalingo.WebApi.Domain.Cleaner;
using Kalingo.WebApi.Domain.Configuration;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.WebApi.Domain.Facades;
using Kalingo.WebApi.Domain.Services;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Startup
{
    public class ContainerConfig
    {
        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        private static IContainer Container { get; set; }
        
        public static IContainer ConfigureAndBuildContainer()
        {
            Container = Configure().Build();

            return Container;
        }

        /// <summary>
        /// For external components to only return the builder. Update on builder will be depreciated
        /// </summary>
        public static ContainerBuilder Configure()
        {
            Builder.RegisterType<UserProcessor>();
            Builder.RegisterType<GameProcessor>();
            Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterDomain();

            return Builder;
        }

        private static void RegisterDomain()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KalingoDb"].ConnectionString;

            Builder.RegisterType<MinesBoomCache>().SingleInstance();
            Builder.RegisterType<RandomProvider>().SingleInstance();
            Builder.RegisterType<RandomGenerator>().SingleInstance();

            Builder.RegisterType<GetUserQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<AddUserCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetFbUserQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<AddFbUserCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetUserPlayCountQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<UpdateUserCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetConfigQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetMinesboomSettingsQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<CreateMinesBoomCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<CloseMinesBoomCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<TerminateMinesBoomCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<AllocateGoldCoinsCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetCaptchaQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<SubmitCaptchaCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetVouchersQuery>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<VoucherClaimedCommand>().WithParameter("connectionString", connectionString).SingleInstance();
            Builder.RegisterType<GetCountriesQuery>().WithParameter("connectionString", connectionString).SingleInstance();

            Builder.RegisterType<UserRepository>().SingleInstance();
            Builder.RegisterType<GamesRepository>().SingleInstance();
            Builder.RegisterType<CaptchaRepository>().SingleInstance();
            Builder.RegisterType<VoucherRepository>().SingleInstance();
            Builder.RegisterType<CountryRepository>().SingleInstance();

            Builder.RegisterType<MinesBoomGameSettings>().SingleInstance();
            Builder.RegisterType<MinesBoomCreationEngine>().SingleInstance();
            Builder.RegisterType<MinesBoomVerificationEngine>().SingleInstance();
            Builder.RegisterType<MinesboomSettings>().SingleInstance();
            Builder.RegisterType<MinesBoomCalculator>().SingleInstance();
            Builder.RegisterType<MinesBoomService>().SingleInstance();
            Builder.RegisterType<MinesBoomCleaner>().SingleInstance();
            Builder.RegisterType<MinesBoomFacade>().SingleInstance();
            Builder.RegisterType<CountryService>().SingleInstance();
            Builder.RegisterType<UserProcessor>().SingleInstance();
            Builder.RegisterType<GameProcessor>().SingleInstance();
            Builder.RegisterType<CaptchaProcessor>().SingleInstance();
            Builder.RegisterType<VoucherProcessor>().SingleInstance();
            Builder.RegisterType<CountryProcessor>().SingleInstance();

            Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}