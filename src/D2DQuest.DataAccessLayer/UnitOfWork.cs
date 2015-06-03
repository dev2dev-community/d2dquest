using System;
using System.Data.Entity;
using System.Linq;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.Contracts.DataAccessLayer.Exceptions;

namespace D2DQuest.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly D2DQuestDbContext _dbContext;

        public UnitOfWork(D2DQuestDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");

            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<T> Items<T>() where T: class
        {
            try
            {
                return GetSet<T>();
            }
            catch(Exception exc)
            {
                throw new DbException(exc);
            }
        }

        public void Attach<T>(T entity) where T : class
        {
            try
            {
                GetSet<T>().Attach(entity);
            }
            catch (Exception exc)
            {
                throw new DbException(exc);
            }
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                GetSet<T>().Add(entity);
            }
            catch(Exception exc)
            {
                throw new DbException(exc);
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            try
            {
                GetSet<T>().Remove(entity);
            }
            catch (Exception exc)
            {
                throw new DbException(exc);
            }
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                throw new DbException(exc);
            }
        }

        private IDbSet<T> GetSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
    }
}
