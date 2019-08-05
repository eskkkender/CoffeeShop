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

        T Repository<T>() where T : IRepositoryBase;

        //IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
