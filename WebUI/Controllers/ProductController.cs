using System.IO;
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
        public IHttpActionResult PostProduct(ProductDTO product)
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

            Service.AddProduct(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
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