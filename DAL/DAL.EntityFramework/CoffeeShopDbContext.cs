using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EntityFramework
{
    public class CoffeeShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        static CoffeeShopDbContext()
        {
            Database.SetInitializer<CoffeeShopDbContext>(new DbInitializer());
        }


    }
    public class DbInitializer : DropCreateDatabaseAlways<CoffeeShopDbContext>
    {
        protected override void Seed(CoffeeShopDbContext db)
        {
            db.Products.Add(new Product { Name = "Nokia Lumia 630" });
            db.Products.Add(new Product { Name = "iPhone 6" });
            db.Products.Add(new Product { Name = "LG G4" });
            db.Products.Add(new Product { Name = "Samsung Galaxy S 6" });
            db.Products.Add(new Product { Name = "Samsung Galaxy S 6" });
            db.SaveChanges();
        }
    }
}
