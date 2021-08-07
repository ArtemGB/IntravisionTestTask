using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Money> Monies { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
