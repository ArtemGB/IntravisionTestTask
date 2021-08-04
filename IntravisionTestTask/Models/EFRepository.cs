using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.Models
{
    public class EFRepository : IDbRepository
    {
        private AppDbContext _db;
        public IQueryable<Product> Products { get; }

        public EFRepository(AppDbContext db)
        {
            _db = db;
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
            throw new System.NotImplementedException();
        }
    }
}