using CoffeeShop.DAL.EF;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        private CoffeeDbContext Db;
        public OrderRepository(CoffeeDbContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return Db.Order.Include(o => o.Coffee);
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

 

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
