using CoffeeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Coffee> Coffee { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
