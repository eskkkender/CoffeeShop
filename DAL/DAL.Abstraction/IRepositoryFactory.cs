using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstraction;
using DAL.Entities.Base;


namespace DAL.Abstraction
{
    public interface IRepositoryFactory
    {
        // T Repository<T>() where T : IRepositoryBase<TEntity>;

      //  T Repositoray<T() where T : IRepositoryBase<T>;
        T Repository<T>() where T : IRepositoryBase;
    }
}
