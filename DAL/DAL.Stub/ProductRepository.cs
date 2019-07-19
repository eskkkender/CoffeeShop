using DAL.Entities;
using DAL.Abstraction;

namespace DAL.Stub
{
    public class ProductRepository : RepositoryBase<Product, long>, IProductRepository
    {
    }
}
