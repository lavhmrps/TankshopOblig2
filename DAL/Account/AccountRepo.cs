using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public class AccountRepo : IAccountRepo
    {
        public List<PersonModel> GetAllPeople()
        {
            using (var db = new TankshopDbContext())
            {
                var people = db.People.Select(p => new PersonModel()
                {
                    PersonId = p.PersonId,
                    Email = p.Email,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Address = p.Address,
                    Zipcode = p.Zipcode,
                    City = p.Postal.City
                }).ToList();

                foreach (var person in people)
                {
                    // If not admin / customer -> id == -1
                    int adminId = -1, customerId = -1;

                    var admin = db.Administrators.FirstOrDefault(a => a.PersonId == person.PersonId);
                    var customer = db.Customers.FirstOrDefault(c => c.PersonId == person.PersonId);

                    if (admin != null)
                    {
                        adminId = admin.AdministratorId;
                    }

                    if (customer != null)
                    {
                        customerId = customer.CustomerId;
                    }

                    person.AdminstratorId = adminId;
                    person.CustomerId = customerId;
                }

                return people;
            }
        }
        
        public bool  AddPerson(PersonModel person)
        {
            var newPerson = new Person()
            {
                Email = person.Email,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Address = person.Address,
                Zipcode = person.Zipcode,

            };
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var personPostal = db.Postals.Find(person.Zipcode);
                    if (personPostal == null)
                    {
                        personPostal = new Postal()
                        {
                            Zipcode = person.Zipcode,
                            City = person.City
                        };
                    }
                    personPostal.People.Add(newPerson);
                    newPerson.Postal = personPostal;

                    db.People.Add(newPerson);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public PersonModel GetPerson(int personId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var personList = GetAllPeople();
                    var person = personList.FirstOrDefault(p => p.PersonId == personId);

                    return person;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public CustomerModel GetCustomer(int customerId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var dbPerson = db.Customers.Find(customerId).Person;
                    var orderRepo = new OrderRepo();

                    var customer = new CustomerModel()
                    {
                        PersonId = dbPerson.PersonId,
                        Firstname = dbPerson.Firstname,
                        Lastname = dbPerson.Lastname,
                        Address = dbPerson.Address,
                        Zipcode = dbPerson.Zipcode,
                        City = dbPerson.Postal.City,
                        CustomerId = customerId,
                        Orders = orderRepo.GetOrders(customerId)
                    };


                    return customer;
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public AdminModel GetAdmin(int adminId)
        {
            using (var db = new TankshopDbContext())
            {
                var dbPerson = db.Administrators.Find(adminId).Person;
                var admin = new AdminModel()
                {
                    PersonId = dbPerson.PersonId,
                    Firstname = dbPerson.Firstname,
                    Lastname = dbPerson.Lastname,
                    Address = dbPerson.Address,
                    Zipcode = dbPerson.Zipcode,
                    City = dbPerson.Postal.City,
                    AdminId = adminId
                };

                return admin;
            }
        }

        // Return true / false on update ok / error
        public bool UpdatePerson(PersonModel personUpdate, int personId)
        {
            // TODO: update admin/customer -id
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var editPerson = db.People.Find(personId);
                    var editPersonModel = GetPerson(personId);

                    editPerson.Email = personUpdate.Email;
                    editPerson.Firstname = personUpdate.Firstname;
                    editPerson.Lastname = personUpdate.Lastname;
                    editPerson.Address = personUpdate.Address;

                    var personPostal = db.Postals.Find(personUpdate.Zipcode);
                    if(personPostal == null)
                    {
                        var oldPostal = db.Postals.Find(editPerson.Zipcode);
                        if (oldPostal != null)
                            oldPostal.People.Remove(editPerson);

                        personPostal = new Postal()
                        {
                            Zipcode = personUpdate.Zipcode,
                            City = personUpdate.City
                        };
                        personPostal.People.Add(editPerson);
                    }

                    editPerson.Zipcode = personUpdate.Zipcode;

                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        // Return PersonModel of deleted person or null on error
        public bool DeletePerson(int personId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var deletePerson = db.People.Find(personId);
                    var deletePersonModel = GetPerson(personId);

                    db.People.Remove(deletePerson);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AttemptLogin(int personId, string password)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var passwordHash = CreateHash(password);
                    var existingUser = db.Credentials.FirstOrDefault(c => c.PersonId == personId && c.Password == passwordHash);

                    if (existingUser == null)
                        return false;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public byte[] CreateHash(string password)
        {
            byte[] inData, outData;
            var alg = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.Default.GetBytes(password);
            outData = alg.ComputeHash(inData);
            return outData;
        }

    }
}
