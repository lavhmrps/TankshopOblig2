using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.DAL
{
    public class CustomerRepoStub : ICustomerRepo
    {
        private List<Order> orderModels;
        private Order orderModel;
        private List<Orderline> orderlineModels;
        private Orderline orderlineModel;
        private Customer customerModel;

        public CustomerRepoStub()
        {
            orderlineModel = new Orderline()
            {
                Count = 1,
                OrderId = 1,
                OrderlineId = 1,
                ProductId = 1,
                ProductName = "Tank",
                ProductPrice = 500000
            };   

            orderlineModels = new List<Orderline>();
            orderlineModels.Add(orderlineModel);
            orderlineModels.Add(orderlineModel);
            orderlineModels.Add(orderlineModel);

            orderModel = new Order()
            {
                CustomerId = 1,
                Date = new DateTime(2015, 1, 1),
                OrderId = 1,
                Orderlines = orderlineModels
            };

            orderModels = new List<Order>();
            orderModels.Add(orderModel);
            orderModels.Add(orderModel);
            orderModels.Add(orderModel);

            customerModel =  new Customer()
            {
                CustomerId = 1,
                Email = "ole@gmail.com",
                Firstname = "Ole",
                Lastname = "Olsen",
                Address = "Persveien 5",
                Postal = new Postal
                {
                    Zipcode = "0123",
                    City = "Oslo"
                },
                Orders = orderModels
            };
        }

        public bool DeleteCustomer(string email)
        {
            if (email == "")
                return false;
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            var customerModels = new List<Customer>();
            customerModels.Add(customerModel);
            customerModels.Add(customerModel);
            customerModels.Add(customerModel);

            return customerModels;

        }

        public Customer GetCustomer(string email)
        {
            if (email == "")
                return new Customer()
                {
                    Firstname = ""
                };
            return customerModel;
        }

        public Customer GetCustomer(int customerId)
        {
            if (customerId == 0)
                return new Customer()
                {
                    Firstname = ""
                };
            return customerModel;
        }
    }
}
