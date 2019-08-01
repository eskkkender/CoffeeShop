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
                var service = container.Resolve<IProductManager>();
                
                //Добавление
                Console.WriteLine($"Вводи товар бля");
                string name = Console.ReadLine();
                service.AddProduct(new DTO.ProductDTO {Name = name});
                Console.WriteLine($"Добавлен новый товар: {name}");

                //Получение всех товаров
                var allAdverts = service.GetAllProducts();
                foreach (var advert in allAdverts)
                {
                    Console.WriteLine(advert.Id);
                    Console.WriteLine(advert.Name);
                }

                //Получение по ИД
                var GetById = service.GetProductId(6);
                Console.WriteLine($"Товар по ИД: {GetById.Name}"); 
           
                //int id = Console.ReadLine();
                //Удаление по ИД
                service.DeleteProduct(2);
                Console.ReadKey();
      
            }
        }
    }
}
