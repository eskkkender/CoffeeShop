using DAL.Abstraction;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        public IRepositoryFactory RepositoryFactory { get; }

        public UnitOfWork(DbContext DbContext, IRepositoryFactory repositoryFactory)
        {       
            _dbContext = DbContext;
            RepositoryFactory = repositoryFactory;
        }

        public T Repository<T>() where T : IRepositoryBase
        {
            return RepositoryFactory.Repository<T>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
