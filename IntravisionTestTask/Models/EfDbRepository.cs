using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.Models
{
    public class EfDbRepository : IDbRepository
    {
        private AppDbContext _db;
        public IQueryable<Product> Products => _db.Products;
        public IQueryable<Money> Monies => _db.Monies;

        public EfDbRepository(AppDbContext db)
        {
            _db = db;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChangesAsync();
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
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
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

        public void Deposit(CoinType type, int count)
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