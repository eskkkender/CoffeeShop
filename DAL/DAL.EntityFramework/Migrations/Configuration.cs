namespace DAL.EntityFramework.Migrations
{
    using DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EntityFramework.CoffeeShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.EntityFramework.CoffeeShopDbContext";
        }

        protected override void Seed(DAL.EntityFramework.CoffeeShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var courses = new List<Product>
            {
                new Product { Price = 123.00, Name = "Нескафе" }
            };
            courses.ForEach(s => context.Products.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
