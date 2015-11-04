using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public interface ICustomerRepo
    {
        bool DeleteCustomer(string email);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomer(int customerId);
        CustomerModel GetCustomer(string email);
    }
}