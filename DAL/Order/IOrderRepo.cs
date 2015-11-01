using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.DAL
{
    public interface IOrderRepo
    {
        int PlaceOrder(OrderModel order);
        OrderModel GetReciept(int orderId);
        List<OrderModel> GetAllOrders();
        bool UpdateOrderline(OrderlineModel orderline);
        double GetOrderSumTotal(int orderId);
        bool DeleteOrder(int orderId);
    }
}
