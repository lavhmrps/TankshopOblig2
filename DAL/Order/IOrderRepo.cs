using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public interface IOrderRepo
    {
        bool DeleteOrder(int orderId);
        List<OrderModel> GetAllOrders();
        OrderModel GetOrder(int orderId);
        List<OrderModel> GetOrders(int customerId);
        double GetOrderSumTotal(int orderId);
        OrderModel GetReciept(int orderId);
        int PlaceOrder(OrderModel order);
        bool UpdateOrderline(OrderlineModel orderline);

    }
}
