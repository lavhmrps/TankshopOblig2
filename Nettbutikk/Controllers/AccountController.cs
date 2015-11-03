﻿using Nettbutikk.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;

namespace Nettbutikk.Controllers
{

    public class AccountController : BaseController
    {
        private IAccountLogic _accountBLL;

        public AccountController()
            : base()
        {
            _accountBLL = new AccountBLL();
        }

        public AccountController(IAccountLogic stub)
        {
            _accountBLL = stub;
        }
        
        [HttpPost]
        public bool Login(string email, string password)
        {

            if (_accountBLL.AttemptLogin(email, password))
            {
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
            var person = new Person()
            {
                Email = customer.Email,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Address = customer.Address,
                Postal = new Postal
                {
                    Zipcode = customer.Zipcode,
                    City = customer.City
                }
            };

            if (_accountBLL.AddPerson(person, Role.Customer, customer.Password))
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
            var Customer = _accountBLL.GetCustomer(Email);
            var customerView = new CustomerView()
            {
                Id= Customer.CustomerId,
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
                        Id = l.ProductId,
                        Name = l.ProductName
                    };

                    order.Orderlines.Add(orderline);
                }
                customerOrders.Add(order);
            }

            //var customerOrders = Customer.Orders.Select(o => new OrderView()
            //{
            //    OrderId = o.OrderId,
            //    Orderlines = o.Orderlines.Select(l => new OrderlineView()
            //    {
            //        OrderlineId = l.OrderlineId,
            //        Count = l.Count,
            //        Product = new ProductView()
            //        {
            //            ProductId = l.ProductId,
            //            ProductName = l.ProductName,
            //            Price = l.ProductPrice
            //        }
            //    }).ToList()
            //}).ToList();

            ViewBag.LoggedIn = LoginStatus();
            ViewBag.Customer = customerView;
            ViewBag.CustomerOrders = customerOrders;

            return View();
        }

        [HttpPost]
        public bool UpdateCustomerInfo(CustomerView customerEdit, string returnUrl)
        {
            var email = (string)Session["Email"];

            var personUpdate = new Person()
            {
                Firstname = customerEdit.Firstname,
                Lastname = customerEdit.Lastname,
                Address = customerEdit.Address,
                Postal = new Postal
                {
                    Zipcode = customerEdit.Zipcode,
                    City = customerEdit.City
                }
            };

            return _accountBLL.UpdatePerson(personUpdate, email);
        }

        [HttpPost]
        public ActionResult UpdatePersonData(CustomerView customerEdit, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var email = customerEdit.Email;

                var personUpdate = new Person()
                {
                    Firstname = customerEdit.Firstname,
                    Lastname = customerEdit.Lastname,
                    Address = customerEdit.Address,
                    Postal = new Postal
                    {
                        Zipcode = customerEdit.Zipcode,
                        City = customerEdit.City
                    }
                };

                if (_accountBLL.UpdatePerson(personUpdate, email))
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

            if (_accountBLL.AttemptLogin(email, CurrentPw))
            {
                if (_accountBLL.ChangePassword(email, NewPassword))
                    return true;
            }
            return false;
        }

        public bool LoginStatus()
        {
            bool LoggedIn = false;
            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool)Session["LoggedIn"];
            }
            return LoggedIn;
        }

    }
}