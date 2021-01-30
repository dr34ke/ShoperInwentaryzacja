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
        public DbSet<UsersShoperToken> ShoperToken { get; set; }
        public DbSet<Inventories> Inventories { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockCheck>().HasKey(m => m.Id);
            builder.Entity<IdentityUser>().HasKey(m => m.Id);
            builder.Entity<UsersShoperToken>().HasKey(m => m.Id);
            builder.Entity<Inventories>().HasKey(m => m.Id);
            builder.Entity<Inventory>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
