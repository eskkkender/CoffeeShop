using DAL.Entities;
using DAL.Abstraction;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository (DbContext context) : base(context)
        {
        }
    }
}
