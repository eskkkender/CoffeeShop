﻿using DAL.Abstraction;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityFramework
{
    public class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly IDbSet<TEntity> DbSet;

        public RepositoryBase(DbContext context)
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
            try
            {
                DbSet.Remove(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
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
