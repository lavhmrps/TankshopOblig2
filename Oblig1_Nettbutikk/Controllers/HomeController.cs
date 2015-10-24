
using Newtonsoft.Json;
using Oblig1_Nettbutikk.Model;
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
            var categories = DB.AllCategories().Select(c => new CategoryView()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.Name
            }
            ).ToList();

            var products = DB.GetProductsByCategory(1).Select( p => new ProductView()
            {
                ProductId = p.ProductId,
                ProductName = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName
            }).ToList();

            ViewBag.Categories = categories ?? new List<CategoryView>();
            ViewBag.Products = products ?? new List<ProductView>();
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = DB.GetCategoryName(1);

            return View();
        }

        public ActionResult Category(int CategoryId)
        {
            var categories = DB.AllCategories().Select(c => new CategoryView()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.Name
            }
            ).ToList();

            var products = DB.GetProductsByCategory(CategoryId).Select(p => new ProductView()
            {
                ProductId = p.ProductId,
                ProductName = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName
            }).ToList(); 

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = DB.GetCategoryName(CategoryId) ?? "Epler?";

            return View("Index");
        }

        public ActionResult Shoppingcart(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.ShoppingCart = new CookieController().GetCartList(this);
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