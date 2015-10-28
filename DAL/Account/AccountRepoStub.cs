using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Nettbutikk.DAL
{
    // For testing
    public class AccountRepoStub : IAccountRepo
    {
        public bool AddPerson(PersonModel person, Role role, string password)
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
                    Email=""
                };
                return admin;
            }
            else
            {
                var admin = new AdminModel()
                {
                    Email = "Test@test.cz",
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
                Email = "Test@test.cz",
                Firstname = "Test",
                Lastname = "Test",
                Address = "Test",
                Zipcode = "1234",
                City = "Test"
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
                    Email = ""
                };
                return customer;
            }
            else
            {
                var customer = new CustomerModel()
                {
                    Email = "Test@test.cz",
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

        public PersonModel GetPerson(string email)
        {
            if (email == "")
            {
                var person = new PersonModel()
                {
                    Email=""
                };
                return person;
            }
            else
            {
                var person = new PersonModel()
                {
                    Email = "Test@test.cz",
                    Firstname = "Test",
                    Lastname = "Test",
                    Address = "Test",
                    Zipcode = "1234",
                    City = "Test"
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

        public bool AttemptLogin(string email, string password)
        {
            if (email == "")
                return false;
            if (password == "")
                return false;
            return true;
        }

        private byte[] CreateHash(string password)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomer(string email)
        {
            throw new NotImplementedException();
        }

        public int GetPersonId(string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(int personId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public AdminModel GetAdmin(string email)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(PersonModel personUpdate, string email)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(string email)
        {
            throw new NotImplementedException();
        }

        public bool CreateCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool SetRole(string email, Role role, bool isRole)
        {
            throw new NotImplementedException();
        }

        public bool isAdmin(string email)
        {
            throw new NotImplementedException();
        }
    }
}
