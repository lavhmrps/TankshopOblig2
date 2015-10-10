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
            var categories = DB.AllCategories();
            var products = DB.GetProductsByCategory(1);

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.LoggedIn = LoginStatus();
            //ViewBag.Category = 2;
            ViewBag.CategoryName = "Default";

            return View();
        }

        public ActionResult Category(int CategoryID)
        {
            var categories = DB.AllCategories();
            var products = DB.GetProductsByCategory(CategoryID);

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.LoggedIn = LoginStatus();
            //ViewBag.CategoryID = CategoryID;
            ViewBag.CategoryName = DB.GetCategoryName(CategoryID) ?? "";

            return View("Index");
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