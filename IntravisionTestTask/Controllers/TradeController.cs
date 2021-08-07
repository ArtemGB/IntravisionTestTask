using System;
using System.Linq;
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
        [Route("Deposit")]
        public JsonResult Deposit(CoinType type, int sessionId)
        {
            try
            {
                _db.Deposit(type, sessionId);
                return new(new { Status = "Success" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new(new { Status = "Error", Message = e.Message });
            }
        }

        [HttpGet]
        [Route("Buy")]
        public JsonResult Buy(int id, string token)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null || product.Quantity <= 0)
                return new(new { Status = "Error", Message = "Товар закончился." });

            Session session = _db.Sessions.FirstOrDefault(s => s.Token == token);
            if (session == null || session.DepositedMoney < product.Price)
                return new(new { Status = "Error", Message = "Недостаточно денег." });

            product.Quantity--;
            _db.EditProduct(product);

            _db.CloseSession(token);
            return new(new { Status = "Success", Odd = session.DepositedMoney - product.Price });
        }
    }
}