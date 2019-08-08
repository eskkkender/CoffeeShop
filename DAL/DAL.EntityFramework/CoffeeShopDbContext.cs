using System.Data.Entity;
using DAL.Entities;

namespace DAL.EntityFramework
{
    public class CoffeeShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        static CoffeeShopDbContext()
        {
            //Database.SetInitializer<CoffeeShopDbContext>(new DbInitializer());
        }
    }
    public class DbInitializer : DropCreateDatabaseAlways<CoffeeShopDbContext>
    {
        protected override void Seed(CoffeeShopDbContext db)
        {
            db.Products.Add(new Product { Name = "Жопадробилка" });
            db.Products.Add(new Product { Name = "Нескафе" });
            db.Products.Add(new Product { Name = "Якобс" });
            db.SaveChanges();
        }
    }
}
