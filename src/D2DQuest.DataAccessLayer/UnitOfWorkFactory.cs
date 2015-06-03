using System;
using System.Linq;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.Contracts.DataAccessLayer.Exceptions;

namespace D2DQuest.DataAccessLayer
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConnectionProvider _provider;

        public UnitOfWorkFactory(IConnectionProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            _provider = provider;
        }

        public IUnitOfWork Create()
        {
            try
            {
                return new UnitOfWork(new D2DQuestDbContext(_provider.GetConnectionStringOrItName()));
            }
            catch (Exception exc)
            {
                throw new DbException(exc);
            }
        }
    }
}
