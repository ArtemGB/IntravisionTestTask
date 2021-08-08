using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.Models
{
    public class EfDbRepository : IDbRepository
    {
        private readonly AppDbContext _db;
        public IQueryable<Product> Products => _db.Products;
        public IQueryable<Money> Monies => _db.Monies;
        public IQueryable<Session> Sessions => _db.Sessions;

        public EfDbRepository(AppDbContext db)
        {
            _db = db;
        }

        public string OpenSession()
        {
            Session session = new Session()
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            };
            _db.Sessions.Add(session);
            _db.SaveChanges();
            return session.Token;
        }

        public void CloseSession(string token)
        {
            Session sessionToClose = _db.Sessions.FirstOrDefault(s => s.Token == token);
            if (sessionToClose != null)
            {
                _db.Sessions.Remove(sessionToClose);
                _db.SaveChanges();
            }
        }

        public Product AddProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Product EditProduct(Product product)
        {
            try
            {
               // _db.Entry(product).State = EntityState.Modified;
               // _db.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoveProduct(int id)
        {
            try
            {
                Product productToDelete = _db.Products.Find(id);
                _db.Products.Remove(productToDelete);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Deposit(CoinType type, int sessionId)
        {
            try
            {
                Money money = _db.Monies.FirstOrDefault(m => m.Type == type);
                Session session = _db.Sessions.Find(sessionId);
                if (money != null && session != null)
                {
                    money.Quantity++;
                    session.DepositedMoney += (int)type;
                    _db.Entry(session).State = EntityState.Modified;
                    _db.Entry(money).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Withdraw(CoinType type, int count)
        {
            try
            {
                Money money = _db.Monies.FirstOrDefault(m => m.Type == type);
                if (money != null)
                {
                    money.Quantity += count;
                    _db.Entry(money).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}