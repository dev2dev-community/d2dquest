using System;
using System.Linq;
using Autofac;
using D2DQuest.BusinessLogic.Commands;
using D2DQuest.BusinessLogic.Queries;
using D2DQuest.Contracts.Commands;
using D2DQuest.Contracts.Queries;

namespace D2DQuest.BusinessLogic.DI
{
    public class BLConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RegisterWordCommand>()
                .As<IRegisterWordCommand>()
                .SingleInstance();

            builder
                .RegisterType<WinnerQuery>()
                .As<IWinnerQuery>()
                .SingleInstance();
        }
    }
}
