using System;
using BLL.Interfaces;
using BLL.Services;
using Castle.MicroKernel.Lifestyle;

namespace ConsoleApp

{
    class Program
    {
        static void Main(string[] args)
        {
            MapperConfigurator.Configure();
            Windsor.Initialize();
            
            var container = Windsor.Container;
            using (Windsor.Container.BeginScope())
            {
                Console.WriteLine($"Вводи товар бля");
                string name = Console.ReadLine();
                var service = container.Resolve<IProductManager>();
                service.AddProduct(new DTO.ProductDTO {Name = name});
                Console.WriteLine($"Добавлен новый товар: {name}");


                var allAdverts = service.GetAllProducts();
                foreach (var advert in allAdverts)
                {
                    Console.WriteLine(advert.Id);
                    Console.WriteLine(advert.Name);
                }

                var a = service.GetProductId(2);
                Console.WriteLine($"Товар по ИД: {a}"); 
                Console.ReadKey();
            }
        }
    }
}
