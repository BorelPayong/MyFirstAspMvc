using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAspMvc.Controllers
{
    [Authorize]
    public class ProductController : Controller //ApiController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /*
         HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new ProductModel[] { });
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        [HttpGet]
        public IHttpActionResult Get(int id, string value)
        {
            return Ok(new { id, value });
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ProductModel model)
        {
            return Ok(model);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] ProductModel model)
        {
            model.Id = id;
            return Ok(new { id, model });
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(new ProductModel { Id = id });
        }
         */
    }
}