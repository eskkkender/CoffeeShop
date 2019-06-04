using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CoffeeShop.Models
{
    public class CoffeeDbInitializer : DropCreateDatabaseAlways<CoffeeContext>
    {
        protected override void Seed(CoffeeContext db)
        {
            db.Coffee.Add(new Coffee { Name = "Nescage", Price = 220, Description = "Бомба кофе" });
            db.Coffee.Add(new Coffee { Name = "Якобс", Price = 180, Description = "Самое лучшее"});

            base.Seed(db);
        }
    }
}