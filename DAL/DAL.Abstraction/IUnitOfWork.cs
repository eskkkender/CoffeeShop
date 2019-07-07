using System;

namespace DAL.Abstraction
{
    /// <summary>
    /// Описание методов для UnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Получить репозиторий
        /// </summary>
        /// <typeparam name="T">тип репозитория</typeparam>
        /// <returns>Репозиторий</returns>
        T Repository<T>() where T : IRepositoryBase;

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();
    }
}
