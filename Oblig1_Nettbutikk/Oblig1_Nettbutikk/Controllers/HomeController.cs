using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LoggedIn = false;
            if(Session["LoggedIn"] != null)
            {
                ViewBag.LoggedIn = (bool)(Session["LoggedIn"]);
            }

            List<Category> categories = DB.AllCategories();
            ViewBag.Categories = categories;

            return View();
        }
    }
}