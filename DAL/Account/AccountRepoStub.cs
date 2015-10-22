using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    // For testing
    public class AccountRepoStub : IAccountRepo
    {
        public bool AddPerson(PersonModel person)
        {
            if (person.Email == "")
                return false;

            return true;
        }

        public bool DeletePerson(int personId)
        {
            if (personId == 0)
                return false;

            return true;
        }

        public AdminModel GetAdmin(int adminId)
        {
            if (adminId == 0)
            {
                var admin = new AdminModel()
                {
                    PersonId = 0
                };
                return admin;
            }
            else
            {
                var admin = new AdminModel()
                {
                    PersonId = 1,
                    Firstname = "Test",
                    Lastname = "Test",
                    Address = "Test",
                    Zipcode = "1234",
                    City = "Test",
                    AdminId = 1
                };
                return admin;
            }
        }

        public List<PersonModel> GetAllPeople()
        {
            var list = new List<PersonModel>();
            var person = new PersonModel()
            {
                PersonId = 1,
                Firstname = "Test",
                Lastname = "Test",
                Address = "Test",
                Zipcode = "1234",
                City = "Test",
                AdminstratorId = 1,
                CustomerId = 1
            };

            list.Add(person);
            list.Add(person);
            list.Add(person);

            return list;
        }

        public CustomerModel GetCustomer(int customerId)
        {
            if (customerId == 0)
            {
                var customer = new CustomerModel()
                {
                    PersonId = 0
                };
                return customer;
            }
            else
            {
                var customer = new CustomerModel()
                {
                    PersonId = 1,
                    Firstname = "Test",
                    Lastname = "Test",
                    Address = "Test",
                    Zipcode = "1234",
                    City = "Test",
                    CustomerId = 1
                };

                return customer;
            }
        }

        public PersonModel GetPerson(int personId)
        {
            if (personId == 0)
            {
                var person = new PersonModel()
                {
                    PersonId = 0
                };
                return person;
            }
            else
            {
                var person = new PersonModel()
                {

                    PersonId = 1,
                    Firstname = "Test",
                    Lastname = "Test",
                    Address = "Test",
                    Zipcode = "1234",
                    City = "Test",
                    AdminstratorId = 1,
                    CustomerId = 1
                };
                return person;
            }
        }

        public bool UpdatePerson(PersonModel personUpdate, int personId)
        {
            if (personId == 0)
                return false;

            return true;
        }

        public bool AttemptLogin(int personId, string password)
        {
            if (personId == 0)
                return false;
            if (password == "")
                return false;
            return true;
        }

        private byte[] CreateHash(string password)
        {
            throw new NotImplementedException();
        }
    }
}
