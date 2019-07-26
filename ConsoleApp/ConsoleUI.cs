using System;
using System.Collections.Generic;
using CoffeeShop.BLL.DTO;
using CoffeeShop.BLL.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.BLL.Interfaces;
using AutoMapper;
using DAL.Entities;
using CoffeeShop.DAL;
using CoffeeShop.DAL.Entities;
using System.Data.Entity;
using DAL.EntityFramework;

namespace ConsoleApp
{
    public class ConsoleUI
    {
    
        CoffeeShopDbContext db = new CoffeeShopDbContext();
        


        public void Start ()
        {
            db.Products.Add(new Product{ Name = "Еще один" });
            db.SaveChanges();

            foreach (var a in db.Products)
            {
                Console.WriteLine(a.Name);
            }

            Console.ReadKey();
        }
        
    }
}
