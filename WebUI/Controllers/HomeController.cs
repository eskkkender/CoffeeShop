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
            ViewBag.Hell = Service.GetAllProducts();
            return View();
        }

        // ветка дев
        [HttpGet]
        public string Add(string name)
        {
            Service.AddProduct(new DTO.ProductDTO { Name = name });
            return "добавлен";
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