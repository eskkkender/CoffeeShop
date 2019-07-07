using DAL.Entities;
using DAL.Abstraction;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public class ProductRepository: RepositoryBase<Product, long>, IProductRepository
    {
        public ProductRepository (DbContext context) : base(context)
        {
        }
    }
}
