using System;
using System.Linq;

namespace DAL.Abstraction
{
    public interface IRepositoryBase
    {
    }
    /// <summary>
    /// Описания общих методов для всех репозиториев
    /// </summary>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        IQueryable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
