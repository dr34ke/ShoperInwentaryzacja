using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoperInwentaryzacja.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<StockCheck> StockChecks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockCheck>().HasKey(m => m.Id);
            builder.Entity<IdentityUser>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
