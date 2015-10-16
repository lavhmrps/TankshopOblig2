
using Newtonsoft.Json;
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

        [HttpPost]
        public int AddToCart(int ProductId)
        {
            var cookie = Request.Cookies["Shoppingcart"] ?? new HttpCookie("Shoppingcart");
            int numProduct;
            try
            {
                numProduct = Convert.ToInt32(cookie[ProductId.ToString()]);
                numProduct++;
            }
            catch (Exception)
            {
                numProduct = 1;
            }
            cookie[ProductId.ToString()] = numProduct.ToString();
            Response.Cookies.Add(cookie);

            var list = cookie.Values;
            var numItemsInCart = 0;
            foreach (var c in list)
            {
                var count = Convert.ToInt32(cookie[c.ToString()]);
                numItemsInCart += count;
            }
            return numItemsInCart;
        }

        public int NumItemsInCart()
        {
            var cookie = Request.Cookies["Shoppingcart"];
            if (cookie == null)
                return 0;

            var list = cookie.Values;
            var numItemsInCart = 0;
            foreach (var c in list)
            {
                var count = Convert.ToInt32(cookie[c.ToString()]);
                numItemsInCart += count;
            }
            return numItemsInCart;
        }

        public string GetCart()
        {
            var cookie = Request.Cookies["Shoppingcart"] ?? new HttpCookie("Shoppingcart");
            var list = cookie.Values;
            var cart = new List<CartItem>();

            using (var db = new WebShopModel())
            {
                foreach (var c in list)
                {
                    var pId = Convert.ToInt32(c);
                    var product = db.Products.Find(pId);
                    var count = Convert.ToInt32(cookie[c.ToString()]);
                    cart.Add(new CartItem
                    {
                        ProductId = pId,
                        Name = product.Name,
                        Price = product.Price,
                        Count = count
                    });

                }
            }
            var jsonCart = JsonConvert.SerializeObject(cart);
            return jsonCart;
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

        public ActionResult Test()
        {
            return PartialView("_ShoppingCartModal");
        }


    }
}