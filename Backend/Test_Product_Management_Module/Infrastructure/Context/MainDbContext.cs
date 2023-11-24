using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId)
                 .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Carts)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
               .HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId)
               .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired();

            modelBuilder.Entity<Cart>()
               .HasOne(c => c.Product)
               .WithMany(p => p.Carts)
               .HasForeignKey(c => c.ProductId)
               .IsRequired();
        }

    }
}
