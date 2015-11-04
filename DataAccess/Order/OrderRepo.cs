using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nettbutikk.DataAccess
{
    public class OrderRepo : IOrderRepo
    {
        private ITankshopDbContext _db;

        private ITankshopDbContext db { get { return _db?? (_db = new TankshopDbContext()); } set { _db = value; } }
        public List<Order> GetOrders(int customerId)
        {
            var customerOrders = new List<Order>();
            var dbOrders = db.Orders.OrderByDescending(o => o.Date);

            foreach (var order in dbOrders)
            {
                if (order.CustomerId == customerId)
                    customerOrders.Add(GetOrder(order.OrderId));
            }

            return customerOrders;
        }

        public Order GetOrder(int orderId)
        {
            var dbOrder = db.Orders.Find(orderId);
            if (dbOrder == null)
                return null;

            var order = new Order()
            {
                CustomerId = dbOrder.CustomerId,
                OrderId = dbOrder.OrderId,
                Orderlines = db.Orderlines.Where(l => l.OrderId == dbOrder.OrderId).Select(l => new Orderline()
                {
                    OrderlineId = l.OrderlineId,
                    OrderId = l.OrderId,
                    ProductId = l.ProductId,
                    Count = l.Count,
                    ProductName = l.Product.Name,
                    ProductPrice = l.Product.Price

                }).ToList(),
                Date = dbOrder.Date
            };

            return order;
        }

        public int PlaceOrder(Order order)
        {
            try
            {
                var newOrder = new Order()
                {
                    CustomerId = order.CustomerId,
                    Date = order.Date
                };

                foreach (var item in order.Orderlines)
                {
                    var product = db.Products.Find(item.ProductId);
                    var orderline = new Orderline()
                    {
                        Product = product,
                        Count = item.Count,
                        ProductId = item.ProductId
                    };

                    newOrder.Orderlines.Add(orderline);
                }

                db.Orders.Add(newOrder);
                db.SaveChanges();
                return newOrder.OrderId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Order GetReciept(int orderId)
        {
            var dbOrder = db.Orders.Find(orderId);
            var orderModel = new Order()
            {
                CustomerId = dbOrder.CustomerId,
                Date = dbOrder.Date,
                OrderId = dbOrder.OrderId,
                Orderlines = dbOrder.Orderlines.Select(l => new Orderline()
                {
                    Count = l.Count,
                    OrderlineId = l.OrderlineId,
                    ProductId = l.ProductId,
                    ProductName = l.Product.Name,
                    ProductPrice = l.Product.Price
                }).ToList()
            };

            return orderModel;
        }

        public IList<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public bool UpdateOrderline(Orderline orderline)
        {
            throw new NotImplementedException();
        }

        public double GetOrderSumTotal(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
