using System.Collections.Generic;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;

namespace Nettbutikk.BusinessLogic
{
    public class AccountBLL : IAccountLogic
    {
      
        private IAccountRepository _repo;
        private ICustomerRepository _customerrepo;

        public AccountBLL()
        {
            _repo = new AccountRepository();
        }

        public AccountBLL(IAccountRepository stub)
        {
            _repo = stub;
        }

        public bool AddPerson(Person person, Role role, string password)
        {
            return _repo.AddPerson(person, role, password);
        }
        

        public Admin GetAdmin(int adminId)
        {
            return _repo.GetAdmin(adminId);
        }

        public List<Person> GetAllPeople()
        {
            return _repo.GetAllPeople();
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerrepo.GetCustomer(customerId);
        }

        public Customer GetCustomer(string email)
        {
            return _customerrepo.GetCustomer(email);
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

        public Admin GetAdmin(string email)
        {
            return _repo.GetAdmin(email);
        }

        public Person GetPerson(string email)
        {
            return _repo.GetPerson(email);
        }

        public bool UpdatePerson(Person personUpdate, string email)
        {
            return _repo.UpdatePerson(personUpdate, email);
        }
    }
}
