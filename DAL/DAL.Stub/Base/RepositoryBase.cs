﻿using DAL.Abstraction;
using DAL.Entities;
using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Stub
{
    public abstract class RepositoryBase<TEntity, PrimaryKey> : IRepositoryBase<TEntity, PrimaryKey> where TEntity : class, BaseEntity<PrimaryKey>
    {

        public void Create(TEntity item)
        {
            string a = "привет";
        }

        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TEntity item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
