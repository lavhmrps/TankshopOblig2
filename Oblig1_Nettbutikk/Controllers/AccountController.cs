using Oblig1_Nettbutikk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.Controllers
{

    public class AccountController : Controller
    {
        private IAccountLogic _accountBLL;

        public AccountController()
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
            var person = new PersonModel()
            {
                Email = customer.Email,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Address = customer.Address,
                Zipcode = customer.Zipcode,
                City = customer.City
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
                CustomerId= Customer.CustomerId,
                Email = Customer.Email,
                Firstname = Customer.Firstname,
                Lastname = Customer.Lastname,
                Address = Customer.Address,
                Zipcode = Customer.Zipcode,
                City = Customer.City
            };

            var customerOrders = Customer.Orders.Select(o => new OrderView()
            { 
                OrderId = o.OrderId,
                Orderlines = o.Orderlines.Select(l => new OrderlineView()
                {
                    OrderlineId = l.OrderlineId,
                    Count = l.Count,
                    Product =  new ProductView()
                    {
                        ProductId = l.ProductId,
                        ProductName = l.Product.ProductName,
                        Descripton = l.Product.Description,
                        Price = l.Product.Price,
                        ImageUrl = l.Product.ImageUrl,
                        Stock = l.Product.Stock,
                        CategoryName = l.Product.CategoryName
                    }
                }).ToList()
            }).ToList();

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

            return _accountBLL.UpdatePerson(personUpdate, email);
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

                if (_accountBLL.UpdatePerson(personUpdate, email))
                {
                    return RedirectToAction("MyPage");
                }
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        public bool ChangePassword2(string CurrentPw, string NewPassword)
        {

            var email = (string)Session["Email"];

            if (_accountBLL.AttemptLogin(email, CurrentPw))
            {
                if (_accountBLL.ChangePassword(email, NewPassword))
                    return true;
            }
            return false;
        }

        public ActionResult Checkout()
        {
            if (LoginStatus())
            {
                var Email = (string)Session["Email"];
                var cart = CookieHandler.GetCartList(this);
                var customer = _accountBLL.GetCustomer(Email);

                ViewBag.Cart = cart;
                ViewBag.Customer = customer;
                ViewBag.LoggedIn = LoginStatus();

                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult PlaceOrder(string returnUrl)
        //{
        //    var cart = CookieHandler.GetCartList(this);
        //    if (cart.Count == 0)
        //    {
        //        return Redirect("Checkout");
        //    }
        //    var OrderId = DB.PlaceOrder((String)Session["Email"], cart);
        //    if (OrderId > 0)
        //    {
        //        CookieHandler.EmptyCart(this);
        //        OrderView Reciept = GetReciept(OrderId);

        //        ViewBag.LoggedIn = LoginStatus();
        //        ViewBag.Reciept = Reciept;

        //        return View("GetReciept");
        //    }
        //    return Redirect(returnUrl);
        //}

        //public OrderView GetReciept(int OrderId)
        //{
        //    var db = new WebShopModel();
        //    var reciept = db.Orders.Where(o => o.OrderID == OrderId).Select(o => new OrderView()
        //    {
        //        OrderId = o.OrderID,
        //        Date = o.Date,
        //        Orderlines = o.Orderlines.Select(l => new OrderlineView
        //        {
        //            OrderlineId = l.OrderlineID,
        //            Product = l.Item,
        //            Count = l.Number
        //        }).ToList()
        //    }).FirstOrDefault();

        //    return reciept;
        //}


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