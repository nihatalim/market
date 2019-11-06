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
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;userid=root;password=;database=market;SslMode=none;CharSet=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            #region Relations

            // Company
            builder.Entity<Company>().HasMany(a => a.Products).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);
            builder.Entity<Company>().HasMany(a => a.Orders).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);
            builder.Entity<Company>().HasMany(a => a.Categories).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);
            builder.Entity<Company>().HasMany(a => a.Clients).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);
            builder.Entity<Company>().HasMany(a => a.Roles).WithOne(a => a.Company).HasForeignKey(a => a.CompanyID);

            // User
            builder.Entity<User>().HasMany(a => a.Roles).WithOne(a => a.User).HasForeignKey(a => a.UserID);

            // Role
            builder.Entity<Role>().HasOne(a => a.Company).WithMany(a => a.Roles).HasForeignKey(a => a.CompanyID);
            builder.Entity<Role>().HasMany(a => a.Users).WithOne(a => a.Role).HasForeignKey(a => a.RoleID);
            builder.Entity<Role>().HasMany(a => a.Privileges).WithOne(a => a.Role).HasForeignKey(a => a.RoleID);

            // Order
            builder.Entity<Order>().HasOne(a => a.Company).WithMany(a => a.Orders).HasForeignKey(a => a.CompanyID);
            builder.Entity<Order>().HasOne(a => a.Client).WithMany(a => a.Orders).HasForeignKey(a => a.ClientID);
            builder.Entity<Order>().HasMany(a => a.Products).WithOne(a => a.Order).HasForeignKey(a => a.OrderID);

            // Product
            builder.Entity<Product>().HasOne(a => a.Company).WithMany(a => a.Products).HasForeignKey(a => a.CompanyID);
            builder.Entity<Product>().HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryID);
            builder.Entity<Product>().HasMany(a => a.Properties).WithOne(a => a.Product).HasForeignKey(a => a.ProductID);

            // Property
            builder.Entity<Property>().HasOne(a => a.Product).WithMany(a => a.Properties).HasForeignKey(a => a.ProductID);

            // Category
            builder.Entity<Category>().HasOne(a => a.Company).WithMany(a => a.Categories).HasForeignKey(a => a.CompanyID);
            builder.Entity<Category>().HasOne(a => a.Parent).WithMany(a => a.Categories).HasForeignKey(a => a.ParentID);

            builder.Entity<Category>().HasMany(a => a.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryID);
            builder.Entity<Category>().HasMany(a => a.Categories).WithOne(a => a.Parent).HasForeignKey(a => a.ParentID);

            // OrderProduct
            builder.Entity<OrderProduct>().HasOne(a => a.Order).WithMany(a => a.Products).HasForeignKey(a => a.OrderID);

            // RolePrivilege
            builder.Entity<RolePrivilege>().HasOne(a => a.Privilege).WithMany().HasForeignKey(a => a.PrivilegeID);
            builder.Entity<RolePrivilege>().HasOne(a => a.Role).WithMany(a => a.Privileges).HasForeignKey(a => a.RoleID);

            // UserRole
            builder.Entity<UserRole>().HasOne(a => a.User).WithMany(a => a.Roles).HasForeignKey(a => a.UserID);
            builder.Entity<UserRole>().HasOne(a => a.Role).WithMany(a => a.Users).HasForeignKey(a => a.RoleID);

            // Client
            builder.Entity<Client>().HasOne(a => a.Company).WithMany(a => a.Clients).HasForeignKey(a => a.CompanyID);
            builder.Entity<Client>().HasMany(a => a.Orders).WithOne(a => a.Client).HasForeignKey(a => a.ClientID);

            #endregion

            #region Indexes

            // Company
            builder.Entity<Company>().HasIndex(a => a.Name);
            builder.Entity<Company>().HasIndex(a => a.IsActive);

            // User
            builder.Entity<User>().HasIndex(a => a.Name);
            builder.Entity<User>().HasIndex(a => a.Mail);
            builder.Entity<User>().HasIndex(a => a.Token);

            // Role
            builder.Entity<Role>().HasIndex(a => a.Name);

            // Privilege
            builder.Entity<Privilege>().HasIndex(a => a.Name);
            builder.Entity<Privilege>().HasIndex(a => a.Number);

            // Order
            builder.Entity<Order>().HasIndex(a => a.IsActive);
            builder.Entity<Order>().HasIndex(a => a.IsConfirmed);
            builder.Entity<Order>().HasIndex(a => a.Type);

            // Product
            builder.Entity<Product>().HasIndex(a => a.Name);
            builder.Entity<Product>().HasIndex(a => a.Barcode);

            // Property
            builder.Entity<Property>().HasIndex(a => a.Name);
            builder.Entity<Property>().HasIndex(a => a.Type);

            // Category
            builder.Entity<Category>().HasIndex(a => a.Name);

            // Client
            builder.Entity<Client>().HasIndex(a => a.Name);
            #endregion
        }
    }
}
