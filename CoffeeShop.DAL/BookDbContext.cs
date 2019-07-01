using CoffeeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL
{
    public class BookDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    public class BookDbInitializer: DropCreateDatabaseAlways<BookDbContext>
    {
        protected override void Seed(BookDbContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир"  });
            db.Books.Add(new Book { Name = "Отцы и дети"});
            db.Books.Add(new Book { Name = "Чайка" });

            base.Seed(db);
        }
    }
}
