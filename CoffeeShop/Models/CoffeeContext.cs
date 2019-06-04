using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext() : base("DefaultConnection")
        { }
        public DbSet<Coffee> Coffee { get; set; }
       // public DbSet<Purchase> Purchases { get; set; }
    }
}