using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Abstraction
{

    /// <summary>
    /// Описания общих методов для всех репозиториев
    /// </summary>
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
