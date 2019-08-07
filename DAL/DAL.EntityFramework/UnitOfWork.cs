using DAL.Abstraction;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;

        public IFactoryRepository RepositoryFactory { get; }

        public UnitOfWork(DbContext DbContext, IFactoryRepository factory)
        {
            RepositoryFactory = factory;
           _dbContext = DbContext;
        }

        public IRepositoryBase Repository<IRepositoryBase>()
        {
            return RepositoryFactory.Repository<IRepositoryBase>();
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
