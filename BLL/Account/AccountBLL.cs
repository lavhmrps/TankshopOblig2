using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.DAL;

namespace Oblig1_Nettbutikk.BLL
{
    public class AccountBLL : IAccountLogic
    {
      
        private IAccountRepo _repo;

        public AccountBLL()
        {
            _repo = new AccountRepo();
        }

        public AccountBLL(IAccountRepo stub)
        {
            _repo = stub;
        }

        public bool AddPerson(PersonModel person, Role role, string password)
        {
            return _repo.AddPerson(person, role, password);
        }
        

        public AdminModel GetAdmin(int adminId)
        {
            return _repo.GetAdmin(adminId);
        }

        public List<PersonModel> GetAllPeople()
        {
            return _repo.GetAllPeople();
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return _repo.GetCustomer(customerId);
        }

        public CustomerModel GetCustomer(string email)
        {
            return _repo.GetCustomer(email);
        }

        public bool AttemptLogin(string email, string password)
        {
            return _repo.AttemptLogin(email, password);
        }

        public bool ChangePassword(string email, string newPassword)
        {
            return _repo.ChangePassword(email, newPassword);
        }

        public bool DeletePerson(string email)
        {
            return _repo.DeletePerson(email);
        }

        public AdminModel GetAdmin(string email)
        {
            return _repo.GetAdmin(email);
        }

        public PersonModel GetPerson(string email)
        {
            return _repo.GetPerson(email);
        }

        public bool UpdatePerson(PersonModel personUpdate, string email)
        {
            return _repo.UpdatePerson(personUpdate, email);
        }

        public bool isAdmin(string email)
        {
            return _repo.isAdmin(email);
        }
        
    }
}
