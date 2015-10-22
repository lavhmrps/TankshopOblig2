using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.DAL
{
    public class OrderRepo
    {
        public List<OrderModel> GetOrders(int customerId)
        {
            using(var db = new TankshopDbContext())
            {
                var customerOrders = new List<OrderModel>();
                var dbOrders = db.Orders.ToList();

                foreach(var order in dbOrders)
                {
                    if(order.CustomerId == customerId)
                        customerOrders.Add(GetOrder(customerId));
                }

                return customerOrders;

            }
        }

        public OrderModel GetOrder(int orderId)
        {
            using (var db = new TankshopDbContext())
            {
                var dbOrder = db.Orders.Find(orderId);
                if (dbOrder == null)
                    return null;

                var order = new OrderModel()
                {
                    CustomerId = dbOrder.CustomerId,
                    OrderId = dbOrder.OrderId,
                    Orderlines = db.Orderlines.Where(l => l.OrderId == dbOrder.OrderId).Select(l => new OrderlineModel()
                    {
                        OrderlineId = l.OrderlineId,
                        OrderId = l.OrderId,
                        ProductId = l.ProductId,
                        Count = l.Count,

                    }).ToList(),
                    Date = dbOrder.Date
                };

                return order;
            }
        }
    }
}
