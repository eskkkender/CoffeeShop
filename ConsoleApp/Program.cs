using System;
using BLL.Interfaces;
using BLL.Services;
using Ioc;
using Castle.MicroKernel.Lifestyle;

namespace ConsoleApp
{
    class Program
    {
 
        static void Main(string[] args)
        {
            MapperConfigurator.Configure();  
            var container = Windsor.Container;
            Windsor.Initialize();
           
            using (container.BeginScope())
            {
                var service = container.Resolve<IProductManager>();
                Console.WriteLine($"Вводи товар бля");
                string name = Console.ReadLine();
                service.AddProduct(new DTO.ProductDTO { Name = name });
                Console.WriteLine($"Добавлен новый товар: {name}");

                // Получение всех товаров
                var allAdverts = service.GetAllProducts();
                foreach (var advert in allAdverts)
                {
                    Console.WriteLine(advert.Id);
                    Console.WriteLine(advert.Name);
                }

                //Получение по ИД
                Console.WriteLine($"Получить по ИД");
                int ID = int.Parse(Console.ReadLine());
                var GetById = service.GetProductId(ID);
                Console.WriteLine($"Товар по ИД: {GetById.Name}");

                //// Удаление по ИД
                //Console.WriteLine($"Удалить");
                //int DeleteId = int.Parse(Console.ReadLine());
                //service.DeleteProduct(DeleteId);

                //// Получение всех товаров после удаления
                //var allAdvertss = service.GetAllProducts();
                //foreach (var advert in allAdvertss)
                //{
                //    Console.WriteLine(advert.Name);
                //}
                //Console.ReadKey();
                Console.WriteLine($"Обновление по ИД");
                string name1 = Console.ReadLine();
                service.EditProduct(new DTO.ProductDTO { Id = 1, Name = name1 }) ;
                var allAdvertss = service.GetAllProducts();
                foreach (var advert in allAdvertss)
                {
                    Console.WriteLine(advert.Id);
                    Console.WriteLine(advert.Name);
                }
                Console.ReadKey();

            }
        }
    }
}
