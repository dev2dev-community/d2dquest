using Autofac;
using Autofac.Integration.Mvc;
using D2DQuest.BusinessLogic.DI;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.DataAccessLayer.DI;
using D2DQuest.Web.MessageHelpers;

namespace D2DQuest.Web.DI
{
    public static class DIConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance<IConnectionProvider>(new ConnectionProvider("D2DQuest"));

            builder.RegisterType<RegistrationMessageHelper>()
                .As<IRegistrationMessageHelper>()
                .SingleInstance();
            builder.RegisterType<RaffleMessageHelper>()
                .As<IRaffleMessageHelper>()
                .SingleInstance();

            builder.RegisterModule<DALConfig>();
            builder.RegisterModule<BLConfig>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            return builder.Build();
        }
    }
}