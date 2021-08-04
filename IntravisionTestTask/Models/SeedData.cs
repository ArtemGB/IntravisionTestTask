﻿using System.Linq;
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
                db.Add(new Product() {Name = "Cola", Price = 30, Quantity = 10});
                db.Add(new Product() {Name = "Pepsi", Price = 40, Quantity = 110});
                db.Add(new Product() {Name = "Fanta", Price = 30.5M, Quantity = 10});
                db.Add(new Product() {Name = "Seven Up", Price = 40.7M, Quantity = 15});
                db.Add(new Product() {Name = "Swepse", Price = 100, Quantity = 50});
                db.Add(new Product() {Name = "Limon Fresh", Price = 80, Quantity = 30});
                db.Add(new Product() {Name = "Байкал", Price = 30, Quantity = 20});
                db.Add(new Product() {Name = "Тархун", Price = 30, Quantity = 10});
                db.SaveChanges();
            }
        }
    }
}