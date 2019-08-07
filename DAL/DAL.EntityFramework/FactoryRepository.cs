using DAL.Abstraction;
using Castle.Windsor;

namespace DAL.EntityFramework
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly IWindsorContainer _container;

        public FactoryRepository(IWindsorContainer container)
        {
            _container = container;
        }

        public IRepositoryBase Repository<IRepositoryBase>()
        {
            return _container.Resolve<IRepositoryBase>();
        }
    }
}
