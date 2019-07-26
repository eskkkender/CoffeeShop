using DAL.Abstraction;

namespace DAL.Stub
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProductRepository pr = new ProductRepository();
        public ProductRepository productRepository {

            get {
                if (pr == null)
                    pr = new ProductRepository();
                return pr;

            }
        }

        public IProductRepository ProductRepository { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Dispose()
        {
        }

        public void SaveChanges()
        {
        }
    }
}
