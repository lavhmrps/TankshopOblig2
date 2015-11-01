using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Nettbutikk.Model
{
    public interface ITankshopDbContext
    {
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<Admin> Admins { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Credential> Credentials { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<OldImage> OldImages { get; set; }
        DbSet<Orderline> Orderlines { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Postal> Postals { get; set; }
        DbSet<Product> Products { get; set; }
    }
}