using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                service.AddProduct(new DTO.ProductDTO { Name = "dskjdskjdskj" });
                
                var allAdverts = service.GetAllProducts();
                foreach (var advert in allAdverts)
                {
                    Console.WriteLine(advert.Name);
                    Console.ReadKey();
                }
            
                
            }
        }
    }
}
