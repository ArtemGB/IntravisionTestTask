using System.Linq;
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
        public JsonResult CreateProduct([FromBody] Product product, [FromQuery]string token)
        {
            if (_db.Sessions.FirstOrDefault(s => s.Token == token) != null)
                return new(_db.AddProduct(product));
            return new(new {Status = "Error", Message = "Incorrect token", Token = token});
        }

        [HttpPost]
        [Route("EditProduct")]
        public JsonResult EditProduct([FromBody] Product product)
        {
            return new(_db.EditProduct(product));
        }
    }
}