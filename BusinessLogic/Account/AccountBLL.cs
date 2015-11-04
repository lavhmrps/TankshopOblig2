using System.Collections.Generic;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;

namespace Nettbutikk.BusinessLogic
{
    public class AccountBLL : IAccountLogic
    {
      
        private IAccountRepository AccountRepository;
        private ICustomerRepository CustomerRepository;

        public AccountBLL()
        {
            AccountRepository = new AccountRepository();
        }

        public AccountBLL(IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            AccountRepository = accountRepository;
            CustomerRepository = customerRepository;
        }

        public bool AddPerson(Person person, Role role, string password)
        {
            return AccountRepository.AddPerson(person, role, password);
        }
        

        public Admin GetAdmin(int adminId)
        {
            return AccountRepository.GetAdmin(adminId);
        }

        public List<Person> GetAllPeople()
        {
            return AccountRepository.GetAllPeople();
        }

        public Customer GetCustomer(int customerId)
        {
            return CustomerRepository.GetCustomer(customerId);
        }

        public Customer GetCustomer(string email)
        {
            return CustomerRepository.GetCustomer(email);
        }

        public bool AttemptLogin(string email, string password)
        {
            return AccountRepository.AttemptLogin(email, password);
        }

        public bool ChangePassword(string email, string newPassword)
        {
            return AccountRepository.ChangePassword(email, newPassword);
        }

        public bool DeletePerson(string email)
        {
            return AccountRepository.DeletePerson(email);
        }

        public Admin GetAdmin(string email)
        {
            return AccountRepository.GetAdmin(email);
        }

        public Person GetPerson(string email)
        {
            return AccountRepository.GetPerson(email);
        }

        public bool UpdatePerson(Person personUpdate, string email)
        {
            return AccountRepository.UpdatePerson(personUpdate, email);
        }
    }
}
