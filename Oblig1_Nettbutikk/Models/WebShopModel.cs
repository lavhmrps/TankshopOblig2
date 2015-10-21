namespace Oblig1_Nettbutikk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class WebShopModel : DbContext
    {
        public WebShopModel()
            : base("name=WebShopModel")
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

        
        public DbSet<Person> People { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        public DbSet<Postal> Postals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        public DbSet<Image> Images { get; set; }

    }

    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }
        public int PersonID { get; set; }

    }

    public class Administrator {
        [Key]
        public int AdministratorID { get; set; }
        public int PersonID { get; set; }
    }

    public class Person {

        [Key]
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }

        public Postal Postal { get; set; }
        public List<Order> Orders { get; set; }

    }

    // Username/password combination
    public class Credential
    {
        [Key]
        public int CredentialID { get; set; }
        public byte[] Password { get; set; }
    }

    // Postaladdress
    public class Postal
    {
        [Key]
        public string Zipcode { get; set; }
        public string City { get; set; }

        public List<Person> Persons { get; set; }
    }

    // Item-category
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }

    }

    // Product
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

    }

    // Complete order
    public class Order
    {
        public Order()
        {
            this.Orderlines = new List<Orderline>();
        }
        [Key]
        public int OrderID { get; set; }
        public string Email { get; set; }
        public virtual List<Orderline> Orderlines { get; set; }
        public DateTime Date { get; set; }
    }

    // Individual orderlines
    public class Orderline
    {
        [Key]
        public int OrderlineID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Number { get; set; }

        public virtual Product Item { get; set; }
        public virtual Order Order { get; set; }
    }

   
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public string  ImageURL{ get; set; }
        public virtual Product Product { get; set; }
    }

}
