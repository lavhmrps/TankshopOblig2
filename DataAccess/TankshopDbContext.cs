using Nettbutikk.Model.RemovedEntities;
using System;
using System.Data.Entity;

namespace Nettbutikk.Model
{
    public class TankshopDbContext : DbContext, ITankshopDbContext
    {
        public TankshopDbContext()
            : base("name=TankshopDbContext")
        {
            try
            {
                Database.CreateIfNotExists();
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                throw;
            }
        }


        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }

        public virtual DbSet<Postal> Postals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<OldProduct> OldProducts { get; set; }
        public virtual DbSet<OldImage> OldImages { get; set; }
    }
}
