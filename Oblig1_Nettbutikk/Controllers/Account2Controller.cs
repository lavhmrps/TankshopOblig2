using Oblig1_Nettbutikk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.BLL;

namespace Oblig1_Nettbutikk.Controllers
{

    public class Account2Controller : Controller
    {
        private IPersonLogic _personBLL ;

        public Account2Controller() {
            _personBLL = new PersonBLL();
        }

        public Account2Controller(IPersonLogic stub)
        {
            _personBLL = stub;
        }
        
        [HttpPost]
        public bool Login(int personId, string password)
        {

            if (_personBLL.AttemptLogin(personId, password))
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
            if (DB.RegisterCustomer(customer))
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
            var Customer = DB.GetCustomerByEmail(Email);
            var Postal = DB.GetPostal(Customer.Zipcode);

            var db = new WebShopModel();

            var cust = db.Customers.Where(c => c.Email == Email).Select(c => new CustomerEditInfo()
            {
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Address = c.Address,
                Zipcode = c.Zipcode,
                City = c.Postal.City
            }).FirstOrDefault();

            var orderList = db.Orders.Where(o => o.Email == Email).Select(o => new OrderView()
            {
                OrderId = o.OrderID,
                Date = o.Date,
                Orderlines = o.Orderlines.Select(l => new OrderlineView
                {
                    OrderlineId = l.OrderlineID,
                    Product = l.Item,
                    Count = l.Number
                }).ToList()
            }).ToList();

            ViewBag.LoggedIn = LoginStatus();
            ViewBag.Customer = cust;
            ViewBag.OrderList = orderList;

            return View();
        }

        [HttpPost]
        public bool UpdateCustomerInfo(CustomerEditInfo customerEdit, string returnUrl)
        {
            return DB.UpdateCustomer(customerEdit, (string)Session["Email"]);
        }

        [HttpPost]
        public ActionResult UpdatePersonData(CustomerEditInfo customerEdit, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (DB.UpdateCustomer(customerEdit, (string)Session["Email"]))
                {
                    return RedirectToAction("MyPage");
                }
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        public bool ChangePassword2(string CurrentPw, string NewPw)
        {

            var Email = (string)Session["Email"];

            CustomerLoginPartial login = new CustomerLoginPartial()
            {
                Email = Email,
                Password = CurrentPw
            };
            if (DB.AttemptLogin(login))
            {
                try
                {
                    var newPasswordHash = DB.CreateHash(NewPw);
                    using (var db = new WebShopModel())
                    {
                        var credentials = db.CustomerCredentials.Find(Email);
                        credentials.Password = newPasswordHash;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public ActionResult Checkout()
        {
            if (LoginStatus())
            {
                var Email = (string)Session["Email"];
                var cart = CookieHandler.GetCartList(this);
                var cust = new WebShopModel().Customers.Where(c => c.Email == Email).Select(c => new CustomerEditInfo()
                {
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Address = c.Address,
                    Zipcode = c.Zipcode,
                    City = c.Postal.City
                }).FirstOrDefault();

                ViewBag.Cart = cart;
                ViewBag.Customer = cust;
                ViewBag.LoggedIn = LoginStatus();

                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PlaceOrder(string returnUrl)
        {
            var cart = CookieHandler.GetCartList(this);
            if (cart.Count == 0)
            {
                return Redirect("Checkout");
            }
            var OrderId = DB.PlaceOrder((String)Session["Email"], cart);
            if (OrderId > 0)
            {
                CookieHandler.EmptyCart(this);
                OrderView Reciept = GetReciept(OrderId);

                ViewBag.LoggedIn = LoginStatus();
                ViewBag.Reciept = Reciept;

                return View("GetReciept");
            }
            return Redirect(returnUrl);
        }

        public OrderView GetReciept(int OrderId)
        {
            var db = new WebShopModel();
            var reciept = db.Orders.Where(o => o.OrderID == OrderId).Select(o => new OrderView()
            {
                OrderId = o.OrderID,
                Date = o.Date,
                Orderlines = o.Orderlines.Select(l => new OrderlineView
                {
                    OrderlineId = l.OrderlineID,
                    Product = l.Item,
                    Count = l.Number
                }).ToList()
            }).FirstOrDefault();

            return reciept;

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