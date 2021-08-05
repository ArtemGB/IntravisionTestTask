using IntravisionTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly IDbRepository _db;

        public TradeController(IDbRepository db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("Index")]
        public JsonResult Index()
        {
            return new(_db.Products);
        }

        [Route("Buy")]
        public JsonResult Buy(int id)
        {

        }
    }
}