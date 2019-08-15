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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public string Add(DTO.ProductDTO  sd)
        {
            Service.AddProduct(sd);
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