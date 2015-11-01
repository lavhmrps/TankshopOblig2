using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nettbutikk.DataAccess
{
    public class AdminRepo : IAdminRepo
    {
        public List<CustomerModel> GetAllCustomers()
        {
            var customerList = new List<CustomerModel>();

            try
            {
                using (var db = new TankshopDbContext())
                {
                    var dbCustomers = db.Customers.ToList();


                    foreach (var c in dbCustomers)
                    {
                        var p = db.People.Find(c.Email);
                        var customer = new CustomerModel()
                        {
                            Email = p.Email,
                            Firstname = p.Firstname,
                            Lastname = p.Lastname,
                            Address = p.Address,
                            Zipcode = p.Zipcode,
                            City = p.Postal.City,
                            CustomerId = c.CustomerId,
                            Orders = c.Orders.Select(o => new OrderModel()
                            {
                                CustomerId = o.CustomerId,
                                Date = o.Date,
                                OrderId = o.OrderId,
                                Orderlines = o.Orderlines.Select(l => new OrderlineModel()
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
    }
}
