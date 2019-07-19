using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Stub;
namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork uw;
        public HomeController()
        {
            uw = new UnitOfWork();
        }
        public ActionResult Index()
        {        
            ViewBag["Head"] = uw.productRepository.GetAll().ToList();
           //ViewData["Head"] = uw.productRepository.Delete();
            return View();
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