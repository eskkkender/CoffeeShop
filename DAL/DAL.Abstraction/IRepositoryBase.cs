using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Abstraction
{
    public interface IRepositoryBase
    {
    }
    /// <summary>
    /// Описания общих методов для всех репозиториев
    /// </summary>
    public interface IRepositoryBase<TEntity, PrimaryKey>: IRepositoryBase where TEntity : BaseEntity<PrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        int Get(int id);
        IQueryable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
