using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public interface IAdminLogic
    {
        IList<CustomerModel> GetAllCustomers();
        bool UpdatePerson(PersonModel personUpdate, string email);
        bool DeleteCustomer(string email);
        IList<OrderModel> GetAllOrders();
        bool UpdateOrderline(OrderlineModel orderline);
        double GetOrderSumTotal(int orderId);
        bool DeleteOrder(int orderId);
    }
}
