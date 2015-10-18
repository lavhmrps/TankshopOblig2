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

        public virtual DbSet<CustomerCredential> CustomerCredentials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Postal> Postals { get; set; }
        public virtual DbSet<CCard> CCards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }
        public virtual DbSet<Shoppingcart> Shoppingcarts { get; set; }
        public virtual DbSet<Image> Images { get; set; }

    }

    // Username/password combination
    public class CustomerCredential
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }

    // Customerinfo
    public class Customer
    {
        [Key]
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }

        public Postal Postal { get; set; }
        public List<CCard> CreditCards { get; set; }
        public List<Order> Orders { get; set; }
    }

    // Postaladdress
    public class Postal
    {
        [Key]
        public string Zipcode { get; set; }
        public string City { get; set; }

        public List<Customer> Customers { get; set; }
    }

    // Creditcard 
    public class CCard
    {
        [Key]
        public string Cardnumber { get; set; }
        public string CCV { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Email { get; set; }
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
        //public DateTime Date { get; set; }
    }

    // Individual orderlines
    public class Orderline
    {
        [Key]
        public int OrderlineID { get; set; }
        public int ProductID { get; set; }
        public int Number { get; set; }
        public virtual Product Item { get; set; }
    }

    // Items in shoppingcart before checkout
    public class Shoppingcart
    {
        public Shoppingcart()
        {
            this.Items = new List<ShoppingcartItem>();
        }
        [Key]
        public string Email { get; set; }
        public virtual  List<ShoppingcartItem> Items { get; set; }
    }

    public class ShoppingcartItem
    {
        [Key]
        public int ShoppingCartItemID { get; set; }
        public int ProductID { get; set; }
        public int Number { get; set; }
        public virtual Shoppingcart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }
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