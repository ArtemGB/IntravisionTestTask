using IntravisionTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IDbRepository _db;

        public AdminController(IDbRepository db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("OpenSession")]
        public JsonResult GetSession()
        {
            return new(new { Token = _db.OpenSession() });
        }

        [HttpGet]
        [Route("Products")]
        public JsonResult GetProducts()
        {
            return new(_db.Products);
        }

        [HttpGet]
        [Route("Money")]
        public JsonResult GetMonies()
        {
            return new(_db.Monies);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public JsonResult CreateProduct(Product product)
        {
            return new(_db.AddProduct(product));
        }
        
        [HttpPost]
        [Route("EditProduct")]
        public JsonResult EditProduct(Product product)
        {
            return new(_db.EditProduct(product));
        }
    }
}