using System.Collections.Generic;
using System.Linq;

namespace IntravisionTestTask.Models
{
    public interface IDbRepository
    {
        IQueryable<Product> Products { get; }
        Product AddProduct(Product product);
        Product EditProduct(Product product);
        void RemoveProduct(int id);

    }
}