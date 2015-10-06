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

        public ActionResult Logout()
        {
            Session["LoggedIn"] = false;
            ViewBag.LoggedIn = false;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public bool Register(CustomerRegisterPartial customer, string returnUrl)
        {
            if (DB.RegisterCustomer(customer))
            {
                Session["LoggedIn"] = true;
                RedirectToAction("Index","Home");
                return true;
            }
            return false;
        }

    }


}