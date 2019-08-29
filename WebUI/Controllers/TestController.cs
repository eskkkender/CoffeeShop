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
            var a = new ProductDTO();

            
            var a = Service.GetAllProducts();
            // return new string[] { "value1", "value2" };
            return Ok(a);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        //...
    }
}