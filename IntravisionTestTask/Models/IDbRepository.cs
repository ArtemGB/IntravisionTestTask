using System.Collections.Generic;
using System.Linq;

namespace IntravisionTestTask.Models
{
    public interface IDbRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Money> Monies { get; }
        IQueryable<Session> Sessions { get; }
        string OpenSession();
        void CloseSession(string token);
        Product AddProduct(Product product);
        Product EditProduct(Product product);
        void RemoveProduct(int id);
        void Deposit(CoinType type, int count);
        void Withdraw(CoinType type, int count);
    }
}