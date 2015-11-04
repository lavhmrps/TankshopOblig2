using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public interface ICustomerRepository
    {
        bool DeleteCustomer(string email);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        Customer GetCustomer(string email);
    }
}