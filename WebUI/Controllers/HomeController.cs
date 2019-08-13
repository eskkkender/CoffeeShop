using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Services;
using Castle.MicroKernel.Lifestyle;
using DAL.EntityFramework;
using GlobalWindsor;
using Castle.Windsor;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        IProductManager ds;

        public HomeController( IProductManager a)
        {
            ds = a;
        }

        public ActionResult Index()
        {
            //var container = Windsor.Container;
            //Windsor.Initialize();

            var allAdverts = ds.GetAllProducts();
            ViewBag.Hell = allAdverts;
            //    var container = Windsor.Container;
            //    container.Install();
            //    Windsor.Initialize();

            //FactoryRepository ds = new FactoryRepository(container);

            //using (container.BeginScope())
            //{
            //    var service = ds.Repository<IProductManager>();
            //    // Получение всех товаров
            //    var allAdverts = service.GetAllProducts();
            //    ViewBag.Message = "Это вызов частичного представления из обычного";
            //    ViewBag.Hell = allAdverts;
            //    return View(allAdverts);
            //}
            return View(allAdverts);

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