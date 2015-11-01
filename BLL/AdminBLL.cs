using Nettbutikk.DataAccess;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    public class AdminBLL :IAdminLogic
    {
        private AdminRepo _repo;
        private IAccountRepo _accountrepo;

        public AdminBLL()
        {
            _repo = new AdminRepo();
            _accountrepo = new AccountRepo();
        }

        public bool DeleteCustomer(string email)
        {
            return _repo.DeleteCustomer(email);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public bool UpdatePerson(PersonModel personUpdate, string email)
        {
            return _accountrepo.UpdatePerson(personUpdate, email);
        }
    }
}
