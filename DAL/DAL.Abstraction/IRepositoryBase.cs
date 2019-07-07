using DAL.Entities.Base;
using System;
using System.Collections.Generic;

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
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
