using Oblig1_Nettbutikk.DAL;
using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.BLL
{
    public class AdminBLL :IAdminLogic
    {
        private AdminRepo _repo;

        public AdminBLL()
        {
            _repo = new AdminRepo();
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
