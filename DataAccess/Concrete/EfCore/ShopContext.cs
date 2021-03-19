using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localdb; Initial Catalog=ShopDb;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.CategoryId, c.ProductId });
        }

    }
}
