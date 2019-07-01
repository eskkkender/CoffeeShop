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

namespace ConsoleApp
{
    public class ConsoleUI
    {

        BookDbContext db = new BookDbContext();
        public void Start ()
        {
            IEnumerable<Book> books = db.Books;
            Console.WriteLine(books);
        }
        
        //IOrderService orderService;
        //public ConsoleUI(IOrderService serv)
        //{
        //    orderService = serv;
        //}
        //public void Start()
        //{
        //    Console.WriteLine("Список всех объявлений:");



        //    IEnumerable<CoffeeDTO> phoneDtos = orderService.GetCoffees();
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeDTO, CoffeeViewModel>()).CreateMapper();
        //    var phones = mapper.Map<IEnumerable<CoffeeDTO>, List<CoffeeViewModel>>(phoneDtos);


        //    Console.WriteLine(phones);
        //    Console.ReadKey();
        //}
    }
}
