using System;
using System.Linq;

namespace D2DQuest.Contracts.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<T> Items<T>() where T: class;

        void Attach<T>(T entity) where T : class;
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;

        void Commit();
    }
}
