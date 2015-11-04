using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nettbutikk.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool DeleteCustomer(string email)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    var dbPerson = db.People.Find(email);
                    var dbCustomer = db.Customers.FirstOrDefault(c => c.Email == email);
                    var dbAdmin = db.Admins.FirstOrDefault(a => a.Email == email);
                    var dbCredentials = db.Credentials.Find(email);

                    if (dbPerson != null)
                        db.People.Remove(dbPerson);
                    if (dbCustomer != null)
                        db.Customers.Remove(dbCustomer);
                    if (dbAdmin != null)
                        db.Admins.Remove(dbAdmin);
                    if (dbCredentials != null) db.Credentials.Remove(dbCredentials);


                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>();

            try
            {
                using (var db = new TankshopDbContext())
                {
                    var dbCustomers = db.Customers.ToList();


                    foreach (var c in dbCustomers)
                    {
                        var p = db.People.Find(c.Email);
                        var customer = new Customer()
                        {
                            Email = p.Email,
                            Firstname = p.Firstname,
                            Lastname = p.Lastname,
                            Address = p.Address,
                            Postal = new Postal
                            {
                            Zipcode = p.Zipcode,
                                City = p.Postal.City
                            },
                            CustomerId = c.CustomerId,
                            Orders = c.Orders.Select(o => new Order()
                            {
                                CustomerId = o.CustomerId,
                                Date = o.Date,
                                OrderId = o.OrderId,
                                Orderlines = o.Orderlines.Select(l => new Orderline()
                                {
                                    Count = l.Count,
                                    OrderId = l.OrderId,
                                    OrderlineId = l.OrderlineId,
                                    ProductId = l.ProductId,
                                    ProductName = l.Product.Name,
                                    ProductPrice = l.Product.Price
                                }).ToList()
                            }).ToList()
                        };
                        customerList.Add(customer);
                    }
                    return customerList;
                }
            }
            catch (Exception)
            {
                return customerList;
            }
        }

        public Customer GetCustomer(string email)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    return db.Customers.Include("Postal,Orders").FirstOrDefault(c => c.Email == email);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Customer GetCustomer(int customerId)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    return db.Customers.Include("Postal,Orders").FirstOrDefault(c => c.CustomerId == customerId);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private Person GetPerson(string email)
        {
            using (var db = new TankshopDbContext())
            {
                try
                {
                    return db.People.Where(p => p.Email == email).FirstOrDefault(); ;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
