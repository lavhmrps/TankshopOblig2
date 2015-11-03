using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.BLL
{
    public interface IAdminLogic
    {
        List<CustomerModel> GetAllCustomers();
        bool UpdatePerson(PersonModel personUpdate, string email);
        bool DeleteCustomer(string email);
        List<OrderModel> GetAllOrders();
        bool UpdateOrderline(OrderlineModel orderline);
        double GetOrderSumTotal(int orderId);
        bool DeleteOrder(int orderId);
        CustomerModel GetCustomer(int customerId);
        List<ProductModel> GetAllProducts();
    }
}
