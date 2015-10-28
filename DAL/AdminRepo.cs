using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class AdminRepo
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
    }
}
