using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        //POST: api/Test
        //public Task<IHttpActionResult> PostProduct(HttpRequest request)
        //{

        //    Trace.WriteLine(request.ToString());
        //    return Ok();
        //}

        public async Task<HttpResponseMessage> PostProduct()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            var qw = HttpContext.Current.Request;
            Trace.WriteLine(qw);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');
                    var filePath = Path.Combine(root, name);
                    File.Move(file.LocalFileName, filePath);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
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