using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntravisionTestTask.Models
{
    public class SeedData
    {
        public static void MakeMigrations(IApplicationBuilder app)
        {
            AppDbContext db = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }
        }

        public static void SeedAllData(IApplicationBuilder app)
        {
            AppDbContext db = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();
            if (!db.Products.Any())
            {
                db.Products.Add(new Product() {ProductName = "Cola", ProductPrice = 30, ProductCount = 10});
                db.Products.Add(new Product() {ProductName = "Pepsi", ProductPrice = 40, ProductCount = 110});
                db.Products.Add(new Product() {ProductName = "Fanta", ProductPrice = 30, ProductCount = 10});
                db.Products.Add(new Product() {ProductName = "Seven Up", ProductPrice = 40, ProductCount = 15});
                db.Products.Add(new Product() {ProductName = "Swepse", ProductPrice = 100, ProductCount = 50});
                db.Products.Add(new Product() {ProductName = "Limon Fresh", ProductPrice = 80, ProductCount = 30});
                db.Products.Add(new Product() {ProductName = "Байкал", ProductPrice = 30, ProductCount = 20});
                db.Products.Add(new Product() {ProductName = "Тархун", ProductPrice = 30, ProductCount = 10});
                db.SaveChanges();
            }

            if (!db.Monies.Any())
            {
                db.Monies.Add(new Money() {CoinPar = CoinType.One, CoinCount = 100});
                db.Monies.Add(new Money() {CoinPar = CoinType.Two, CoinCount = 100});
                db.Monies.Add(new Money() {CoinPar = CoinType.Five, CoinCount = 100});
                db.Monies.Add(new Money() {CoinPar = CoinType.Ten, CoinCount = 100});
                db.SaveChanges();
            }
        }
    }
}