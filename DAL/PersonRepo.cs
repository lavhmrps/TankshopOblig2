using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public class PersonRepo : IPersonRepo
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
                    // If not admin / customer
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

        // Returns the PersonId or -1 on error
        public int AddPerson(PersonModel person)
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
                    return person.PersonId;
                }
                catch (Exception)
                {
                    return -1;
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

        public PersonModel GetCustomer(int customerId)
        {
            using (var db = new TankshopDbContext())
            {
                var customer = db.Customers.Find(customerId);
                return GetPerson(customer.PersonId);
            }
        }

        public PersonModel GetAdmin(int adminId)
        {
            using (var db = new TankshopDbContext())
            {
                var admin = db.Administrators.Find(adminId);
                return GetPerson(admin.PersonId);
            }
        }

        // Return true / false on update ok / error
        public bool UpdatePerson(PersonModel personUpdate, int personId)
        {
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
        public PersonModel DeletePerson(int personId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var deletePerson = db.People.Find(personId);
                    var deletePersonModel = GetPerson(personId);

                    db.People.Remove(deletePerson);
                    db.SaveChanges();

                    return deletePersonModel;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

    }
}
