using System;
using System.Collections.Generic;
using System.Linq;
using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private TankshopDbContext db = new TankshopDbContext();

        public List<Person> GetAllPeople()
        {
            return db.People.ToList();
        }

        public bool AddPerson(Person person, Role role, string password)
        {
            var email = person.Email;
            using (var transaction = db.Database.BeginTransaction())
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
                    personPostal.People.Add(person);
                    person.Postal = personPostal;


                    // Create email / password - combination
                    var existingCredentials = db.Credentials.Find(email);
                    if (existingCredentials != null)
                        return false;

                    var passwordHash = CreateHash(password);
                    var newCredentials = new Credential()
                    {
                        Email = email,
                        Password = passwordHash
                    };
                    db.Credentials.Add(newCredentials);

                    // Set Customer / AdminId
                    int AdminId = 0, CustomerId = 0;
                    if (role == Role.Admin)
                    {
                        var dbAdmin = db.Admins.FirstOrDefault(a => a.Email == email);
                        if (dbAdmin == null)
                        {
                            dbAdmin = new Admin()
                            {
                                Email = email
                            };
                            db.Admins.Add(dbAdmin);
                        }
                        AdminId = dbAdmin.AdminId;
                    }
                    if (role == Role.Customer)
                    {
                        var dbCustomer = db.Customers.FirstOrDefault(c => c.Email == email);
                        if (dbCustomer == null)
                        {
                            dbCustomer = new Customer()
                            {
                                Email = email
                            };
                            db.Customers.Add(dbCustomer);
                        }
                        CustomerId = dbCustomer.CustomerId;

                    }

                    db.People.Add(person);

                    db.SaveChanges();
                    transaction.Commit();

                    return true;

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool CreateCredentials(string email, string password)
        {
            try
            {
                var existingCredentials = db.Credentials.Find(email);
                if (existingCredentials != null)
                    return false;

                var passwordHash = CreateHash(password);
                var newCredentials = new Credential()
                {
                    Email = email,
                    Password = passwordHash
                };
                db.Credentials.Add(newCredentials);

                //db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool SetRole(string email, Role role, bool isRole)
        {
            try
            {
                if (role == Role.Admin)
                {
                    var dbAdmin = db.Admins.Find(email);
                    if (isRole)
                    {
                        if (dbAdmin == null)
                        {
                            var newAdmin = new Admin()
                            {
                                Email = email
                            };
                            db.Admins.Add(newAdmin);
                        }
                    }
                    else
                    {
                        db.Admins.Remove(dbAdmin);
                    }
                }
                if (role == Role.Customer)
                {
                    var dbCustomer = db.Customers.Find(email);
                    if (isRole)
                    {
                        if (dbCustomer == null)
                        {
                            var newCustomer = new Customer()
                            {
                                Email = email
                            };
                            db.Customers.Add(newCustomer);
                        }
                    }
                    else
                    {
                        db.Customers.Remove(dbCustomer);
                    }
                }
                //db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Person GetPerson(string email)
        {
            try
            {

                var person = db.People.Where(p => p.Email == email).Select(p => new Person()
                {
                    Email = p.Email,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Address = p.Address,
                    Postal = p.Postal
                }).Single();

                return person;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetCustomer(int customerId)
        {
            try
            {
                return db.Customers.Include("Orders").FirstOrDefault(c => c.CustomerId == customerId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetCustomer(string email)
        {
            try
            {
                var dbPerson = GetPerson(email);
                
                return db.Customers.Include("Orders").FirstOrDefault(c => c.Email == email);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Admin GetAdmin(int adminId)
        {
            var dbAdmin = db.Admins.FirstOrDefault(a => a.AdminId == adminId);
            var dbPerson = GetPerson(dbAdmin.Email);
            var admin = new Admin()
            {
                AdminId = adminId,
                Email = dbPerson.Email,
                Firstname = dbPerson.Firstname,
                Lastname = dbPerson.Lastname,
                Address = dbPerson.Address,
                Postal = dbPerson.Postal
            };

            return admin;
        }

        public Admin GetAdmin(string email)
        {
            var adminId = db.Admins.FirstOrDefault(a => a.Email == email).AdminId;
            var dbPerson = GetPerson(email);
            var admin = new Admin()
            {
                AdminId = adminId,
                Email = dbPerson.Email,
                Firstname = dbPerson.Firstname,
                Lastname = dbPerson.Lastname,
                Address = dbPerson.Address,
                Postal = dbPerson.Postal
            };

            return admin;
        }

        public bool UpdatePerson(Person personUpdate, string email)
        {
            try
            {
                var editPerson = db.People.Find(email);
                var editPersonModel = GetPerson(email);

                editPerson.Firstname = personUpdate.Firstname;
                editPerson.Lastname = personUpdate.Lastname;
                editPerson.Address = personUpdate.Address;

                var personPostal = db.Postals.Find(personUpdate.Zipcode);
                if (personPostal == null)
                {
                    var oldPostal = db.Postals.Find(editPerson.Zipcode);
                    if (oldPostal != null)
                        oldPostal.People.Remove(editPerson);
                    db.SaveChanges();

                    personPostal = new Postal()
                    {
                        Zipcode = personUpdate.Zipcode,
                        City = personUpdate.City
                    };
                    personPostal.People.Add(editPerson);
                    db.SaveChanges();
                }

                editPerson.Zipcode = personUpdate.Zipcode;
                editPerson.Postal = personPostal;

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePerson(string email)
        {
            try
            {
                var deletePerson = db.People.Find(email);
                var deleteCustomer = db.Customers.FirstOrDefault(c => c.Email == email);
                var deleteAdmin = db.Admins.FirstOrDefault(a => a.Email == email);

                if (deletePerson != null)
                    db.People.Remove(deletePerson);
                if (deleteCustomer != null)
                    db.Customers.Remove(deleteCustomer);
                if (deleteAdmin != null)
                    db.Admins.Remove(deleteAdmin);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AttemptLogin(string email, string password)
        {
            try
            {
                var passwordHash = CreateHash(password);
                var existingUser = db.Credentials.FirstOrDefault(c => c.Email == email && c.Password == passwordHash);

                if (existingUser == null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private byte[] CreateHash(string password)
        {
            byte[] inData, outData;
            var alg = System.Security.Cryptography.SHA256.Create();

            inData = System.Text.Encoding.Default.GetBytes(password);
            outData = alg.ComputeHash(inData);

            return outData;
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                var newPasswordHash = CreateHash(newPassword);
                var existingUser = db.Credentials.Find(email);
                if (existingUser == null)
                    return false;

                existingUser.Password = newPasswordHash;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
