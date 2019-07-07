using DAL.Entities;

namespace DAL.Abstraction
{
    public interface IProductRepository : IRepositoryBase<Product, long>
    {
    }
}
