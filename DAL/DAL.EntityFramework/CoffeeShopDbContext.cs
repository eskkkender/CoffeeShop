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
            db.Products.Add(new Product { Price = 57.00, Name = "Жопадробилка", Description = "gjg", FileUrl = "ссылка" });
            db.Products.Add(new Product { Price = 123.00, Name = "Нескафе", Description = "wew" });
            db.Products.Add(new Product { Price = 10.00, Name = "Якобс", Description = "gassajg" });
            db.SaveChanges();
        }
    }
}
