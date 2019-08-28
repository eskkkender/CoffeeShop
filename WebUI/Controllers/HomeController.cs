using System.Web.Mvc;
using BLL.Interfaces;
using DTO;

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
        public ActionResult Add(ProductDTO item)
        {
            Service.AddProduct(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var GetProductById = Service.GetProductId(id);
            return View(GetProductById);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Service.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetProductById = Service.GetProductId(id);
            return View(GetProductById);
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO item)
        {
            Service.EditProduct(item);      
            return RedirectToAction("Index");
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