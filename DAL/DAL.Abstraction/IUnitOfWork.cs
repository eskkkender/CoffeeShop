using DAL.Entities;
using System;

namespace DAL.Abstraction
{
    /// <summary>
    /// Описание методов для UnitOfWork
    /// </summary>
    interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Save();
    }
}
