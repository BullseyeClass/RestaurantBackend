using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Context
{
    public class MyAppContext : IdentityDbContext<Customer>
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) 
        {
                
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerSupport> CustomerSupports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-one relationship between CustomerSupport and Customer
            modelBuilder.Entity<CustomerSupport>()
                .HasKey(c => c.Id); // Set the primary key for CustomerSupport

            modelBuilder.Entity<CustomerSupport>()
                .HasOne<Customer>(cs => cs.Customer) // CustomerSupport has one Customer
                .WithOne(c => c.CustomerSupport)    // Customer has one CustomerSupport
                .HasForeignKey<CustomerSupport>(cs => cs.CustomerId) // Foreign key
                .OnDelete(DeleteBehavior.Restrict); // Set the delete behavior
        }
    }
}
