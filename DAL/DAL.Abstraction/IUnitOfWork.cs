using System;


namespace DAL.Abstraction
{
    /// <summary>
    /// Описание методов для UnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IFactoryRepository RepositoryFactory { get; }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();

        IRepositoryBase Repository<IRepositoryBase>();
    }
}
