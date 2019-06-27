using CoffeeShop.DAL.EF;
using CoffeeShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Repositories
{
    public class CoffeeRepository : IRepository<Coffee>
    {
        private CoffeeDbContext Db;

        public CoffeeRepository(CoffeeDbContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Coffee> GetAll()
        {
            return Db.Coffee;
        }

        public Coffee Get(int id)
        {
            return Db.Coffee.Find(id);
        }

        public IEnumerable<Coffee> Find(Func<Coffee, bool> predicate)
        {
            return Db.Coffee.Where(predicate).ToList();
        }

     
        public void Create(Coffee coffee)
        {
            Db.Coffee.Add(coffee);
        }

        public void Delete(int id)
        {
            Coffee coffee = Db.Coffee.Find(id);
            if (coffee != null)
                Db.Coffee.Remove(coffee);
        }


        public void Update(Coffee coffee)
        {
            Db.Entry(coffee).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
