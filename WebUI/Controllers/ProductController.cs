using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.Interfaces;
using DTO;

namespace WebUI.Controllers
{
    public class ProductController : ApiController
    {

        protected IProductManager Service;

        public ProductController(IProductManager service)
        {
            Service = service;
        }

        // GET api/Test
        public IHttpActionResult Get()
        {          
            var a = Service.GetAllProducts();
            return Ok(a);
        }

        // GET api/Test/5
        public IHttpActionResult Get(int id)
        {
            var a = Service.GetProductId(id);
            return Ok(a);
        }

        // POST: api/Test
        public HttpResponseMessage PostProduct()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (ModelState.IsValid)
            //{

            //        if (FileUrl != null)
            //        {
            //            string FileName = Path.GetFileName(FileUrl.FileName);
            //            string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/images/"), FileName);
            //            product.FileUrl = FileName;
            //            Service.AddProduct(product);

            //            FileUrl.SaveAs(path);

            //        }

            //}

            //Service.AddProduct(product);

            //if (HttpContext.Current.Request.Files.AllKeys.Any())
            //{
            // // Get the uploaded image from the Files collection
            // var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

            // if (httpPostedFile != null)
            // {
            // // Get the complete file path
            // String fileSavePath = HttpContext.Current.Server.MapPath("~/Content/images/") + HttpContext.Current.Request.Form["ImageName"];

            // // Save the uploaded file to "UploadedFiles" folder
            // httpPostedFile.SaveAs(fileSavePath);
            // }
            //}

            HttpResponseMessage result;
            var httpRequest = HttpContext.Current.Request;

            // Check if files are available
            //if (httpRequest.Files.Count > 0)
            //{
            var files = new List<string>();

            // interate the files and save on the server

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/Content/images/" + postedFile.FileName);
                postedFile.SaveAs(filePath);

                files.Add(filePath);
            }

            // return result
            result = Request.CreateResponse(HttpStatusCode.Created, files);
            //}
            //else
            //{
            // // return BadRequest (no file(s) available)
            // result = Request.CreateResponse(HttpStatusCode.BadRequest);
            //}
            return result;
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            Service.DeleteProduct(id);
            return Ok();
        }

        public IHttpActionResult PutProduct(int id ,ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            Service.EditProduct(product);
            return Ok();
        }

    }
}