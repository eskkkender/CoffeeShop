using DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;

        //public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IFactoryRepository RepositoryFactory { get; }

        public UnitOfWork(DbContext DbContext, IFactoryRepository factory)
        {
            RepositoryFactory = factory;
           _dbContext = DbContext;
        }

        public T Repository<T>() where T : IRepositoryBase
        {
            return RepositoryFactory.Repository<T>();
        }

        //public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class
        //{
        //    if (repositories.Keys.Contains(typeof(TEntity)) == true)
        //    {
        //        return repositories[typeof(TEntity)] as IRepositoryBase<TEntity>;
        //    }

        //    IRepositoryBase<TEntity> repo = new RepositoryBase<TEntity>(_dbContext);
        //    repositories.Add(typeof(TEntity), repo);
        //    return repo;
        //}

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

 
    }
}
