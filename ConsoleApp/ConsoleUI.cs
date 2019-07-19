using System;
using System.Collections.Generic;
using CoffeeShop.BLL.DTO;
using CoffeeShop.BLL.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.BLL.Interfaces;
using AutoMapper;
using CoffeeShop.DAL;
using CoffeeShop.DAL.Entities;
using System.Data.Entity;
using DAL.EntityFramework;

namespace ConsoleApp
{
    public class ConsoleUI
    {
    
        CoffeeShopDbContext db = new CoffeeShopDbContext();
        private UnitOfWork uw = new UnitOfWork();

        public void Start ()
        {
            var a = uw.productRepository.GetAll();
            Console.WriteLine(a.ToList());
            //foreach (var a in db.Products)
            //{
            //    Console.WriteLine(a.Name);
            //}
            //Console.WriteLine(db.Products);
            Console.ReadKey();
        }
        
    }
}
