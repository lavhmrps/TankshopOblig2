using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public interface ICustomerLogic
    {
        IList<Customer> GetAllCustomers();
        bool UpdatePerson(Person personUpdate, string email);
        bool DeleteCustomer(string email);
        IList<Order> GetAllOrders();
        bool UpdateOrderline(Orderline orderline);
        double GetOrderSumTotal(int orderId);
        bool DeleteOrder(int orderId);
        Customer GetCustomer(int customerId);
        ICollection<Product> GetAllProducts();
    }
}
