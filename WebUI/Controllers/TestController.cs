using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Interfaces;
using DTO;


namespace WebUI.Controllers
{
    public class TestController : ApiController
    {

        protected IProductManager Service;

        public TestController(IProductManager service)
        {
            Service = service;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {          
            var a = Service.GetAllProducts();
            return Ok(a);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var a = Service.GetProductId(id);
            return Ok(a);
        }

        // POST: api/Books
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostBook(ProductDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Service.AddProduct(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

    }
}