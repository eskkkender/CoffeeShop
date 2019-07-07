using DAL.Abstraction;
using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public abstract class RepositoryBase<TEntity, PrimaryKey> : IRepositoryBase<TEntity, PrimaryKey> where TEntity : class, BaseEntity<PrimaryKey>
    {
        protected readonly DbContext Context;
        private readonly IDbSet<TEntity> DbSet;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
