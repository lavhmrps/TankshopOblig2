using System.Collections.Generic;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public interface IAdminRepo
    {
        bool DeleteCustomer(string email);
        List<CustomerModel> GetAllCustomers();
    }
}