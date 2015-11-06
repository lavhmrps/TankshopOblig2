using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.BLL
{
    public interface IOrderLogic
    {
        bool DeleteOrder(int orderId);
        List<OrderModel> GetAllOrders();
        List<ProductModel> GetAllProducts();
        OrderModel GetOrder(int OrderId);
        List<OrderModel> GetOrders(int CustomerId);
        double GetOrderSumTotal(int orderId);
        OrderModel GetReciept(int orderId);
        int PlaceOrder(OrderModel order);
        bool UpdateOrderline(OrderlineModel orderline);
    }
}