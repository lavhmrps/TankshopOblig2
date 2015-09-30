using Microsoft.AspNet.Identity.EntityFramework;
using Nettbutikk.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;


namespace Nettbutikk.DAL
{
    public class NettbutikkContext : IdentityDbContext<User>
    {

        public NettbutikkContext() : base("Nettbutikk")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        internal static NettbutikkContext Create()
        {
            return new NettbutikkContext();
        }
    }
}
