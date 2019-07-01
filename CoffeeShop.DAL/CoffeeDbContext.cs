using CoffeeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.EF
{
    // Класс контекста данных
    public class CoffeeDbContext : DbContext
    {
        public DbSet<Coffee> Coffee { get; set; }

        public DbSet<Order> Order { get; set; }

        static CoffeeDbContext()
        {
            Database.SetInitializer<CoffeeDbContext>(new StoreDbInitializer());
        }

        public CoffeeDbContext(string connectionString): base(connectionString)
        {
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CoffeeDbContext>
        {
            protected override void Seed(CoffeeDbContext db)
            {
                //Добавлять что-то через сидинг
                db.Coffee.Add(new Coffee { Name = "Nokia Lumia 630", Price = 220 });
                db.Coffee.Add(new Coffee { Name = "iPhone 6", Price = 320 });
                db.Coffee.Add(new Coffee { Name = "LG G4",  Price = 260 });
                db.Coffee.Add(new Coffee { Name = "Samsung Galaxy S 6",  Price = 300 });
                db.SaveChanges();
            }

        }
    }
}
