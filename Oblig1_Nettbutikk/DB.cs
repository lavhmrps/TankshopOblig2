using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk
{
    public class DB
    {
      
        public static Product GetProductById(int productId)
        {
            using (var db = new TankshopDbContext())
            {
                return db.Products.Find(productId);
            }
        }

        internal static List<Product> GetProductsByCategory(int categoryId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    List<Product> AllProducts = db.Products.ToList();
                    List<Product> products = new List<Product>();

                    foreach (var product in AllProducts)
                        if (product.Category.CategoryId == categoryId)
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
            using (var db = new TankshopDbContext())
            {
                return db.Postals.Find(zipcode);
            }
        }

     

        public static string GetCategoryName(int categoryId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var category = db.Categories.Find(categoryId);

                    return category.Name;
                }
                catch (Exception)
                {
                    return "Eple";
                }

            }
        }

        internal static List<Category> AllCategories()
        {
            using (var db = new TankshopDbContext())
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

       
        
        

        //public static OrderView GetReciept(int orderId)
        //{
        //    using (var db = new TankshopDbContext())
        //    {
        //        var OrderView = db.Orders.Where(o => o.OrderId == orderId).Select(o => new OrderView()
        //        {
        //            OrderId = o.OrderId,
        //            Date = o.Date,
        //            Orderlines = o.Orderlines.Select(l => new OrderlineView
        //            {
        //                OrderlineId = l.OrderlineId,
        //                Product = l.Product,
        //                Count = l.Count
        //            }).ToList()
        //        }).FirstOrDefault();

        //        return OrderView;
        //    }
        //}

        //public static int PlaceOrder(string email, List<CartItem> cart)
        //{
        //    using (var db = new TankshopDbContext())
        //    {
        //        try
        //        {
        //            var Order = new Order();

        //            var Customer = GetCustomer(email);

        //            Order.Email = email;
        //            Order.Date = DateTime.Now;

        //            foreach (var item in cart)
        //            {
        //                var Product = GetProductById(item.ProductId);
        //                var Orderline = new Orderline();

        //                Orderline.Item = Product;
        //                Orderline.Number = item.Count;
        //                Orderline.ProductId = item.ProductId;

        //                Order.Orderlines.Add(Orderline);
        //            }
        //            db.Orders.Add(Order);
        //            //Customer.Orders.Add(Order);
        //            db.SaveChanges();
        //            return Order.OrderId;
        //        }
        //        catch (Exception)
        //        {
        //            return -1;
        //        }

        //    }
        //}
    }
}