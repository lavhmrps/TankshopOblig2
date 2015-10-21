using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk
{
    public class DB
    {
        public static bool AttemptLogin(CustomerLoginPartial user)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    //var existingUser = db.CustomerCredentials.Find(user.Email);
                    var passwordHash = CreateHash(user.Password);
                    var existingUser = db.CustomerCredentials.FirstOrDefault(u => u.Email == user.Email && u.Password == passwordHash);

                    if (existingUser == null)
                        return false;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static Product GetProductById(int productId)
        {
            using (var db = new WebShopModel())
            {
                return db.Products.Find(productId);
            }
        }

        internal static List<Product> GetProductsByCategory(int categoryID)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    List<Product> AllProducts = db.Products.ToList();
                    List<Product> products = new List<Product>();

                    foreach (var product in AllProducts)
                        if (product.Category.CategoryID == categoryID)
                            products.Add(product);

                    return products;
                }
                catch (Exception)
                {
                    return new List<Product>();
                    throw;
                }
            }
        }

        public static Postal GetPostal(string zipcode)
        {
            using (var db = new WebShopModel())
            {
                return db.Postals.Find(zipcode);
            }
        }

        public static Customer GetCustomerByEmail(string email)
        {
            using (var db = new WebShopModel())
            {
                var customer = db.Customers.Find(email);
                return customer;
            }
        }

        public static string GetCategoryName(int categoryID)
        {
            using (var db = new WebShopModel())
            {
                var category = db.Categories.Find(categoryID);

                return category.Name;

            }
        }

        internal static List<Category> AllCategories()
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    return db.Categories.ToList();
                }
                catch (Exception)
                {
                    return new List<Category>();
                }
            }
        }

        public static bool UpdateCustomer(CustomerEditInfo updates, string email)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    var Customer = db.Customers.Find(email);
                    Customer.Firstname = updates.Firstname;
                    Customer.Lastname = updates.Lastname;
                    Customer.Address = updates.Address;

                    if (Customer.Zipcode != updates.Zipcode)
                    {
                        Customer.Zipcode = updates.Zipcode;
                        var oldPostal = db.Postals.Find(Customer.Zipcode);
                        var newPostal = db.Postals.Find(updates.Zipcode);

                        if (newPostal == null)
                        {
                            newPostal = new Postal()
                            {
                                Zipcode = updates.Zipcode,
                                City = updates.City,
                                Customers = new List<Customer>()
                            };
                        }
                        newPostal.Customers.Add(Customer);
                        Customer.Postal = newPostal;
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static byte[] CreateHash(string password)
        {
            byte[] inData, outData;
            var alg = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.Default.GetBytes(password);
            outData = alg.ComputeHash(inData);
            return outData;
        }

        public static bool RegisterCustomer(CustomerRegisterPartial customer)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    var existingCustomer = db.Customers.Find(customer.Email);
                    if (existingCustomer != null)
                        return false;
                    var newCustomer = new Customer
                    {
                        Email = customer.Email,
                        Firstname = customer.Firstname,
                        Lastname = customer.Lastname,
                        Address = customer.Address,
                        Zipcode = customer.Zipcode
                    };

                    var customerPostal = db.Postals.Find(customer.Zipcode);
                    if (customerPostal == null)
                    {
                        customerPostal = new Postal
                        {
                            Zipcode = customer.Zipcode,
                            City = customer.City,
                            Customers = new List<Customer>()
                        };
                    }

                    newCustomer.Postal = customerPostal;
                    customerPostal.Customers.Add(newCustomer);

                    var newCustomerCredential = new CustomerCredential
                    {
                        Email = customer.Email,
                        Password = CreateHash(customer.Password)
                    };

                    db.Customers.Add(newCustomer);
                    db.CustomerCredentials.Add(newCustomerCredential);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static OrderView GetReciept(int orderId)
        {
            using (var db = new WebShopModel())
            {
                var OrderView = db.Orders.Where(o => o.OrderID == orderId).Select(o => new OrderView()
                {
                    OrderId = o.OrderID,
                    Date = o.Date,
                    Orderlines = o.Orderlines.Select(l => new OrderlineView
                    {
                        OrderlineId = l.OrderlineID,
                        Product = l.Item    ,
                        Count = l.Number
                    }).ToList()
                }).FirstOrDefault();

                return OrderView;
            }
        }

        public static int PlaceOrder(string email, List<CartItem> cart)
        {
            using (var db = new WebShopModel())
            {
                try
                {
                    var Order = new Order();
                    
                    var Customer = GetCustomerByEmail(email);

                    Order.Email = email;
                    Order.Date = DateTime.Now;

                    foreach (var item in cart)
                    {
                        var Product = GetProductById(item.ProductId);
                        var Orderline = new Orderline();

                        Orderline.Item = Product;
                        Orderline.Number = item.Count;
                        Orderline.ProductID = item.ProductId;

                        Order.Orderlines.Add(Orderline);
                    }
                    db.Orders.Add(Order);
                    //Customer.Orders.Add(Order);
                    db.SaveChanges();
                    return Order.OrderID;
                }
                catch (Exception)
                {
                    return -1;
                }

            }
        }
    }
}