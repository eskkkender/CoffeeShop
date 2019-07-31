using System;

namespace DAL.Abstraction
{
    /// <summary>
    /// Описание методов для UnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий товара
        /// </summary>
        IProductRepository ProductRepository { get; set; }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();

        IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
