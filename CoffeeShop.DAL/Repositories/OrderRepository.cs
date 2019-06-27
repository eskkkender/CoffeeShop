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
            return Db.Order;
        }

        public void Create(Order order)
        {
            Db.Order.Add( order );
        }

        public void Delete(int id)
        {
            Order order = Db.Order.Find(id);
            if (order != null)
                Db.Order.Remove(order);
        }

        public void Update(Order order)
        {
            Db.Entry(order).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return Db.Order.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return Db.Order.Find(id);
        }


  
    }
}
