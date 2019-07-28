using DAL.Abstraction;
using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
           DbSet.Add(item);
        }

        public void Delete(TEntity item)
        {
            DbSet.Remove(item);
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
