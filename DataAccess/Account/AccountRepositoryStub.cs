using System;
using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    // For testing
    public class AccountRepositoryStub : IAccountRepository
    {
        public bool AddPerson(Person person, Role role, string password)
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

        public Admin GetAdmin(int adminId)
        {
            if (adminId == 0)
            {
                var admin = new Admin()
                {
                    Email=""
                };
                return admin;
            }
            else
            {
                var admin = new Admin()
                {
                    Email = "ole@gmail.com",
                    Firstname = "Ole",
                    Lastname = "Olsen",
                    Address = "Persveien 5",
                    Postal = new Postal
                    {
                        Zipcode = "1234",
                        City = "Test"
                    },
                    AdminId = 1
                };
                return admin;
            }
        }

        public List<Person> GetAllPeople()
        {
            var list = new List<Person>();
            var person = new Person()
            {
                Email = "ole@gmail.com",
                Firstname = "Ole",
                Lastname = "Olsen",
                Address = "Persveien 5",
                Postal = new Postal
                {
                    Zipcode = "1234",
                    City = "Test"
                }
            };

            list.Add(person);
            list.Add(person);
            list.Add(person);

            return list;
        }

        public Customer GetCustomer(int customerId)
        {
            if (customerId == 0)
            {
                var customer = new Customer()
                {
                    Email = ""
                };
                return customer;
            }
            else
            {
                return new Customer()
                {
                    Email = "Test@test.cz",
                    Firstname = "Test",
                    Lastname = "Test",
                    Address = "Test",
                    Postal = new Postal
                    {
                        Zipcode = "1234",
                        City = "Test"
                    },
                    CustomerId = 1
                };
            }
        }


        public Person GetPerson(string email)
        {
            if (email == "")
            {
                var person = new Person()
                {
                    Email=""
                };
                return person;
            }
            else
            {
                var person = new Person()
                {
                    Email = "ole@gmail.com",
                    Firstname = "Ole",
                    Lastname = "Olsen",
                    Address = "Persveien 5",
                    Postal = new Postal
                    {
                        Zipcode = "1234",
                        City = "Test"
                    }
                };
                return person;
            }
        }

        public bool UpdatePerson(Person personUpdate, int personId)
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

        public Customer GetCustomer(string email)
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

        public Admin GetAdmin(string email)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person personUpdate, string email)
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
    }
}
