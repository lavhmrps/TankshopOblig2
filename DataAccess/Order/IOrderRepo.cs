using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public interface IOrderRepo
    {
        int PlaceOrder(Order order);
        Order GetReciept(int orderId);
        IList<Order> GetAllOrders();
        bool UpdateOrderline(Orderline orderline);
        double GetOrderSumTotal(int orderId);
        bool DeleteOrder(int orderId);
    }
}
