using System;
using System.Linq;

namespace D2DQuest.Contracts.DataAccessLayer
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
