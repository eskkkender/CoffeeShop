using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IFactoryRepository
    {

        T Repository<T>() where T : IRepositoryBase;
    }
}
