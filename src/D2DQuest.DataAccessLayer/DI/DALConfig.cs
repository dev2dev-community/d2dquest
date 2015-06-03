using System;
using System.Linq;
using Autofac;
using D2DQuest.Contracts.DataAccessLayer;

namespace D2DQuest.DataAccessLayer.DI
{
    public class DALConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UnitOfWorkFactory>()
                .As<IUnitOfWorkFactory>()
                .SingleInstance();
        }
    }
}
