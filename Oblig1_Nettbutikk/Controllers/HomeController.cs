
using Newtonsoft.Json;
using Oblig1_Nettbutikk.Model;
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

            ViewBag.Categories = categories ?? new List<Category>();
            ViewBag.Products = products ?? new List<Product>();
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = DB.GetCategoryName(1);

            return View();
        }

        public ActionResult Category(int CategoryID)
        {
            var categories = DB.AllCategories();
            var products = DB.GetProductsByCategory(CategoryID);

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = DB.GetCategoryName(CategoryID) ?? "";

            return View("Index");
        }

        public ActionResult ShoppingCart(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.ShoppingCart = CookieHandler.GetCartList(this);
            ViewBag.LoggedIn = LoginStatus();
            return View();
        }

        [HttpPost]
        public int AddToCart(int ProductId)
        {
            return CookieHandler.AddToCart(this, ProductId);
        }

        public int NumItemsInCart()
        {
            return CookieHandler.NumItemsInCart(this);
        }

        public string GetCart()
        {
            var cart = CookieHandler.GetCartList(this);

            var jsonCart = JsonConvert.SerializeObject(cart);
            return jsonCart;
        }

        [HttpPost]
        public int RemoveFromCart(int ProductId)
        {
            CookieHandler.RemoveFromCart(ProductId, this);

            return CookieHandler.NumItemsInCart(this);
        }

        public double GetSumTotalCart()
        {
            return CookieHandler.GetSumTotalCart(this);
        }

        public int UpdateCartProductCount(int ProductId, int Count)
        {
            CookieHandler.UpdateCartProductCount(ProductId, Count, this);

            return CookieHandler.NumItemsInCart(this);

        }

        public ActionResult EmptyCart(string returnUrl)
        {
            CookieHandler.EmptyCart(this);

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