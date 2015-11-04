using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public interface IAdminRepo
    {
        bool DeleteCustomer(string email);
        List<Customer> GetAllCustomers();
    }
}