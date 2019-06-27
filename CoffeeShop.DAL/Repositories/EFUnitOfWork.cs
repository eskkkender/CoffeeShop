using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.DAL.EF;
using CoffeeShop.DAL.Interfaces;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Repositories;

namespace CoffeeShop.DAL.Repositories
{
    public class EFUnitOfWork
    {
        private CoffeeDbContext Db;
        private CoffeeRepository CoffeeRepository;
        private OrderRepository OrderRepository;

        public EFUnitOfWork(string connectionString)
        {
            Db = new CoffeeDbContext(connectionString);
        }
        public IRepository<Coffee> Coffee
        {
            get
            {
                if (CoffeeRepository == null)
                    CoffeeRepository = new CoffeeRepository(Db);
                return CoffeeRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (OrderRepository == null)
                    OrderRepository = new OrderRepository(Db);
                return OrderRepository;
            }
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
}
