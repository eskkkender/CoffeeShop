using System.Web.Mvc;
using BLL.Interfaces;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        protected IProductManager Service;

        public HomeController(IProductManager service)
        {
            Service = service;
        }

        public ActionResult Index()
        {
            var allAdverts = Service.GetAllProducts();
            ViewBag.Hell = allAdverts;
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