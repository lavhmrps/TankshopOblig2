using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.DAL;

namespace Oblig1_Nettbutikk.BLL
{
    public class AccountBLL : IAccountRepo
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

        public bool AddPerson(PersonModel person)
        {
            return _repo.AddPerson(person);
        }

        public bool DeletePerson(int personId)
        {
            return _repo.DeletePerson(personId);
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

        public PersonModel GetPerson(int personId)
        {
            return _repo.GetPerson(personId);
        }

        public bool UpdatePerson(PersonModel personUpdate, int personId)
        {
            return _repo.UpdatePerson(personUpdate, personId);
        }

        public bool AttemptLogin(int personId, string password)
        {
            return _sec.AttemptLogin(personId, password);
        }
    }
}
