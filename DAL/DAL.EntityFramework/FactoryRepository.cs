using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public T Repository<T>() where T : IRepositoryBase
        {
            return _container.Resolve<T>();
        }
    }
}
