using System;
using BLL.Interfaces;
using BLL.Services;
using Castle.MicroKernel.Lifestyle;
using DAL.EntityFramework;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MapperConfigurator.Configure();  
            var container = Windsor.Container;
            FactoryRepository ds = new FactoryRepository(container);
            container.Install();
            Windsor.Initialize();

            using (container.BeginScope())
            {
                 var service = ds.Repository<IProductManager>();
                // Добавление товара
                Console.WriteLine($"Вводи товар бля");
                string name = Console.ReadLine();
                service.AddProduct(new DTO.ProductDTO { Name = name });
                Console.WriteLine($"Добавлен новый товар: {name}");

                // Получение всех товаров
                var allAdverts = service.GetAllProducts();
                foreach (var advert in allAdverts)
                {
                    Console.WriteLine(advert.Name);
                }

                //Получение по ИД
                var GetById = service.GetProductId(1);
                Console.WriteLine($"Товар по ИД: {GetById.Name}");

                // Удаление по ИД
                service.DeleteProduct(2);
                // Получение всех товаров после удаления
                var allAdvertss = service.GetAllProducts();
                foreach (var advert in allAdvertss)
                {
                    Console.WriteLine(advert.Name);
                }
                Console.ReadKey();
      
            }
        }
    }
}
