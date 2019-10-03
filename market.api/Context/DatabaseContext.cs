using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using market.api.Models;
using Microsoft.Extensions.Configuration;

namespace market.api.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Property> Properties { get; set; }

        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;password=;database=market;SslMode=none;CharSet=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Relations

            // Company
            builder.Entity<Company>().HasOne(a => a.User).WithMany().HasForeignKey(t => t.UserID);

            builder.Entity<Company>().HasMany(a => a.Products).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);
            builder.Entity<Company>().HasMany(a => a.Orders).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);

            // Product
            builder.Entity<Product>().HasOne(a => a.Company).WithMany(a => a.Products).HasForeignKey(a => a.CompanyID);
            builder.Entity<Product>().HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryID);

            builder.Entity<Product>().HasMany(a => a.Properties).WithOne(a => a.Product).HasForeignKey(a => a.ProductID);

            // Order
            builder.Entity<Order>().HasOne(a => a.Company).WithMany(a => a.Orders).HasForeignKey(a => a.CompanyID);

            builder.Entity<Order>().HasMany(a => a.OrderProducts).WithOne(a => a.Order).HasForeignKey(a => a.OrderID);

            // OrderProduct
            builder.Entity<OrderProduct>().HasOne(a => a.Order).WithMany(a => a.OrderProducts).HasForeignKey(a => a.OrderID);
            builder.Entity<OrderProduct>().HasOne(a => a.Product).WithMany(a => a.OrderProducts).HasForeignKey(a => a.ProductID);

            // Property
            builder.Entity<Property>().HasOne(a => a.Product).WithMany(a => a.Properties).HasForeignKey(a => a.ProductID);

            // Category
            builder.Entity<Category>().HasOne(a => a.Company).WithMany(a => a.Categories).HasForeignKey(a => a.CompanyID);

            builder.Entity<Category>().HasMany(a => a.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryID);

            #endregion

            #region Others
            // Product
            builder.Entity<Product>().HasIndex(a => a.Name);
            builder.Entity<Product>().HasIndex(a => a.Barcode);

            // Order
            builder.Entity<Order>().HasIndex(a => a.OrderNumber);
            builder.Entity<Order>().HasIndex(a => a.Type);

            // User
            builder.Entity<User>().HasIndex(a => a.Mail);
            builder.Entity<User>().HasIndex(a => a.Token);

            // Property
            builder.Entity<Property>().HasIndex(a => a.Name);
            //builder.Entity<Property>().HasIndex(a => a.Value);
            builder.Entity<Property>().HasIndex(a => a.PropertyType);

            // Category
            builder.Entity<Category>().HasIndex(a => a.Name);

            #endregion

        }
    }
}
