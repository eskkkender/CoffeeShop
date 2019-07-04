using DAL.Entities;
using System;

namespace DAL.Abstraction
{
    /// <summary>
    /// Описание методов для UnitOfWork
    /// </summary>
    interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Product> Product { get; }
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Save();
    }
}
