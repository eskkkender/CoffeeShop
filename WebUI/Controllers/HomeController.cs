using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
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
        public ActionResult Add(ProductDTO item, HttpPostedFileBase FileUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (FileUrl != null)
                    {
                        string FileName = Path.GetFileName(FileUrl.FileName);
                        string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/images/"), FileName);
                        item.FileUrl = FileName;
                        Service.AddProduct(item);

                        FileUrl.SaveAs(path);

                        byte[] imageData;
                        using (var binaryReader = new BinaryReader(FileUrl.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(FileUrl.ContentLength);
                        }
                        Trace.WriteLine(imageData);
                    }
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }

            return View("Add");
        }



        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ProductDTO item, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/images/"), Path.GetFileName(file.FileName));                    
                        file.SaveAs(path);
                        ViewBag.FileName = path;
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
               
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }
            Service.AddProduct(item);
            return View("Upload");
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
        public ActionResult Detail(int id)
        {
            var GetProductById = Service.GetProductId(id);
            return View(GetProductById);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetProductById = Service.GetProductId(id);
            return View(GetProductById);
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO item, HttpPostedFileBase FileUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (FileUrl != null)
                    {
                        string FileName = Path.GetFileName(FileUrl.FileName);
                        string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/images/"), FileName);
                        item.FileUrl = FileName;
                        Service.EditProduct(item);
                        FileUrl.SaveAs(path);
                        ViewBag.FileName = path;
                    }
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading.";
                }
            }    
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