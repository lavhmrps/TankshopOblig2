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

            var categories = DB.AllCategories();
            var products = DB.GetProductsByCategory(1);

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View();
        }

        public ActionResult Category (int CategoryID)
        {
            var categories = DB.AllCategories();
            var products = DB.GetProductsByCategory(CategoryID);

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View("Index");
        }
    }
}