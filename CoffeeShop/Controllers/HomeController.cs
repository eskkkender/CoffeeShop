using CoffeeShop.Models;
using CoffeeShop.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();
        CoffeeContext Db = new CoffeeContext();

        public ActionResult Index()
        {
            var coffee = Db.Coffee;
            return View(coffee);
        }

        [Authorize(Roles = "admin")]
        public ViewResult About()
        {
            ViewData["Head"] = "<h1>Дарова</h1>"; 
            ViewBag.Message = "My page";
            
            return View("~/Views/Home/About.cshtml");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            Purchase purchase = new Purchase { BookId = id  }; 
            return View(purchase);
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();

            return "Спасибо," + purchase.Person + ", за покупку!";

        }
        
        public ActionResult Detail(int id)
        {
            Coffee a = Db.Coffee.Find(id);
            if ( a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }


        public ActionResult GetVoid(int id)
        {
            if ( id > 3)
            {
                return new HttpUnauthorizedResult();
            }

            return View("About");
        }

        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);

            Coffee coffee = Db.Coffee.Find(id);
            if (coffee != null)
            {
                return View(coffee);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Coffee coffee)
        {
            Db.Entry(coffee).State = EntityState.Modified;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Coffee coffee)
        {
            Db.Coffee.Add(coffee);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Coffee b = Db.Coffee.Find(id);
            if ( b == null)
            {
                return HttpNotFound();
            }
            return View(b);

        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee b = Db.Coffee.Find(id);
            if ( b == null )
            {
                return HttpNotFound();
            }
            Db.Coffee.Remove(b);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}