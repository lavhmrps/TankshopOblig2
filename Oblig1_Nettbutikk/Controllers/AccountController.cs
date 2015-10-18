using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{

    public class AccountController : Controller
    {

        [HttpPost]
        public bool Login(string email, string password)
        {
            var customerLogin = new CustomerLoginPartial
            {
                Email = email,
                Password = password
            };

            if (DB.AttemptLogin(customerLogin))
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
                //Session["LoggedIn"] = false;
                //Session["Email"] = null;
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

            var orderList = db.Orders.Where(o => o.Email == Email).Select(o => new OrderView() {
                OrderId = o.OrderID,
                Orderlines = o.Orderlines.ToList()
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
            if(ModelState.IsValid)
            {
                if(DB.UpdateCustomer(customerEdit, (string)Session["Email"]))
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

        [HttpPost]
        public ActionResult ChangePassword(CustomerChangePassword changePw, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var Email = (string)Session["Email"];

                CustomerLoginPartial login = new CustomerLoginPartial()
                {
                    Email = Email,
                    Password = changePw.CurrentPassword
                };
                if(DB.AttemptLogin(login))
                {
                    var newPasswordHash = DB.CreateHash(changePw.NewPassword);
                    using (var db = new WebShopModel())
                    {
                        var credentials = db.CustomerCredentials.Find(Email);
                        credentials.Password = newPasswordHash;
                        db.SaveChanges();

                        return RedirectToAction("MyPage");
                    }
                }
            }
            return Redirect(returnUrl);
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