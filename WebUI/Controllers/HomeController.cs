using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Services;
using Castle.MicroKernel.Lifestyle;
using DAL.EntityFramework;


namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //MapperConfigurator.Configure();
            var container = Windsor.Container;           
            FactoryRepository ds = new FactoryRepository(container);
            container.Install();
            Windsor.Initialize();
            using (container.BeginScope())
            {
                var service = ds.Repository<IProductManager>();
                // Получение всех товаров
                var allAdverts = service.GetAllProducts();
                ViewBag.Message = "Это вызов частичного представления из обычного";
                ViewBag.Hell = allAdverts;
                return View(allAdverts);
            }
               
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}