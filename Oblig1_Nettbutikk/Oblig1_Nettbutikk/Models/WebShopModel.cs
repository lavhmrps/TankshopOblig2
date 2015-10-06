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
            : base("name=WebShopModel2")
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
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Postal> Postals { get; set; }
        public virtual DbSet<CCard> CCards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }
        public virtual DbSet<Shoppingcart> Shoppingcarts { get; set; }
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
        public Postal Postal { get; set; }
        public List<CCard> CreditCards { get; set; }
    }

    // Postaladdress
    public class Postal
    {
        [Key]
        public string Zipcode { get; set; }
        public string City { get; set; }
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
        public List<Item> Items { get; set; }

    }

    // Sellable Item
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

    }

    // Complete order
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Email { get; set; }
        public List<Orderline> Orderlines { get; set; }
        public DateTime Date { get; set; }
    }

    // Individual orderlines
    public class Orderline
    {
        [Key]
        public int OrderlineID { get; set; }
        public Item Item { get; set; }
        public int Number { get; set; }
    }

    // Items in shoppingcart before checkout
    public class Shoppingcart
    {
        [Key]
        public string Email { get; set; }
        public List<ShoppingcartItem> Items { get; set; }
    }

    public class ShoppingcartItem
    {
        [Key]
        public int ShoppingCartItemID { get; set; }
        public Shoppingcart ShoppingCart { get; set; }
        public Item Item { get; set; }
    }

}