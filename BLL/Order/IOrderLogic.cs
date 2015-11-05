using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.BLL
{
    public interface IOrderLogic
    {
        bool DeleteOrder(int orderId);
        List<OrderModel> GetAllOrders();
        //List<Order> GetAllOrders();
        double GetOrderSumTotal(int orderId);
        OrderModel GetReciept(int orderId);
        //Order GetReciept(int orderId);
        int PlaceOrder(OrderModel order);
        bool UpdateOrderline(OrderlineModel orderline);
        List<ProductModel> GetAllProducts();
        CustomerModel GetCustomer(int customerId);
    }
}