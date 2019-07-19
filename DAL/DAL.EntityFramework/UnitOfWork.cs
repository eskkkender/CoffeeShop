using DAL.Abstraction;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;

        public ProductRepository productRepository { get; set; }

        //public UnitOfWork(DbContext DbContext)
        //{       
        //    _dbContext = DbContext;
        //}

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
