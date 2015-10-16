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
            Session["LoggedIn"] = false;
            Session["Email"] = null;
            ViewBag.LoggedIn = false;

        }

        [HttpPost]
        public bool Register(CustomerRegisterPartial customer, string returnUrl)
        {
            if (DB.RegisterCustomer(customer))
            {
                Session["LoggedIn"] = true;
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
            string Email;
            Email = (string)Session["Email"];
            var Customer = DB.GetCustomerByEmail(Email);

            ViewBag.Customer = Customer;
            ViewBag.LoggedIn = LoginStatus();

            return View();
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