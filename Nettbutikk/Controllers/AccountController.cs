using Nettbutikk.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.Model;

namespace Nettbutikk.Controllers
{

    public class AccountController : BaseController
    {
        [HttpPost]
        public bool Login(string email, string password)
        {

            if (Services.Accounts.AttemptLogin(email, password))
            {
                if (Services.Accounts.isAdmin(email))
                    Session["Admin"] = true;
                else
                    Session["Admin"] = false;

                Session["LoggedIn"] = true;
                Session["Email"] = email;
                ViewBag.LoggedIn = true;
                return true;
            }
            else
            {
                Session["LoggedIn"] = false;
                ViewBag.LoggedIn = false;
            }
            return false;
        }

        public void Logout()
        {
            Session.Abandon();
            ViewBag.LoggedIn = false;
        }

        [HttpPost]
        public bool Register(CustomerRegisterPartial customer, string returnUrl)
        {
            var person = new PersonModel()
            {
                Email = customer.Email,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Address = customer.Address,
                Zipcode = customer.Zipcode,
                City = customer.City
            };

            if (Services.Accounts.AddPerson(person, Role.Customer, customer.Password))
            {
                Session["LoggedIn"] = true;
                Session["Email"] = customer.Email;
                RedirectToAction("Index", "Home");
                return true;
            }
            return false;
        }


        public ActionResult MyPage()
        {
            if (!LoginStatus())
            {
                return RedirectToAction("Index", "Home");
            }

            string Email = (string)Session["Email"];
            var Customer = Services.Accounts.GetCustomer(Email);
            var customerView = new CustomerView()
            {
                CustomerId = Customer.CustomerId,
                Email = Customer.Email,
                Firstname = Customer.Firstname,
                Lastname = Customer.Lastname,
                Address = Customer.Address,
                Zipcode = Customer.Zipcode,
                City = Customer.City
            };

            var orders = Customer.Orders;
            var customerOrders = new List<OrderView>();

            foreach (var o in orders)
            {
                var order = new OrderView();
                order.Date = o.Date;
                order.OrderId = o.OrderId;
                order.Orderlines = new List<OrderlineView>();

                foreach(var l in o.Orderlines)
                {
                    var orderline = new OrderlineView();
                    orderline.Count = l.Count;
                    orderline.OrderlineId = l.OrderlineId;
                    orderline.Product = new ProductView()
                    {
                        Price = l.ProductPrice,
                        ProductId = l.ProductId,
                        ProductName = l.ProductName
                    };

                    order.Orderlines.Add(orderline);
                }
                customerOrders.Add(order);
            }

            ViewBag.LoggedIn = LoginStatus();
            ViewBag.Customer = customerView;
            ViewBag.CustomerOrders = customerOrders;

            return View();
        }

        [HttpPost]
        public bool UpdateCustomerInfo(CustomerView customerEdit, string returnUrl)
        {
            var email = (string)Session["Email"];

            var personUpdate = new PersonModel()
            {
                Firstname = customerEdit.Firstname,
                Lastname = customerEdit.Lastname,
                Address = customerEdit.Address,
                Zipcode = customerEdit.Zipcode,
                City = customerEdit.City
            };

            return Services.Accounts.UpdatePerson(personUpdate, email);
        }

        [HttpPost]
        public ActionResult UpdatePersonData(CustomerView customerEdit, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var email = customerEdit.Email;

                var personUpdate = new PersonModel()
                {
                    Firstname = customerEdit.Firstname,
                    Lastname = customerEdit.Lastname,
                    Address = customerEdit.Address,
                    Zipcode = customerEdit.Zipcode,
                    City = customerEdit.City
                };

                if (Services.Accounts.UpdatePerson(personUpdate, email))
                {
                    return RedirectToAction("MyPage");
                }
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        public bool ChangePassword(string CurrentPw, string NewPassword)
        {

            var email = (string)Session["Email"];

            if (Services.Accounts.AttemptLogin(email, CurrentPw))
            {
                if (Services.Accounts.ChangePassword(email, NewPassword))
                    return true;
            }
            return false;
        }
    }
}