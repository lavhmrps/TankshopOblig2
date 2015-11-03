using Newtonsoft.Json;
using Nettbutikk.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CartController : BaseController
    {
        private const string SHOPPINGCART = "Shoppingcart";

        public CartController()
            : base()
        {
        }

        public ActionResult Cart(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.ShoppingCart = GetCartItems();
            ViewBag.LoggedIn = Session["LoggedIn"] ?? false;
            return View("Shoppingcart");
        }

        [HttpPost]
        public int AddToCart(int ProductId)
        {
            return CookieHandler.AddToCart(ProductId);
        }
        public void EmptyCart()
        {
            CookieHandler.EmptyCart();
        }

        public string GetCartJson()
        {
            return JsonConvert.SerializeObject(GetCartItems());
        }

        public IEnumerable<CartItem> GetCartItems()
            {
            return Services.Products.GetAll<CartItem>(CookieHandler.GetCartProductIds());
        }

        public double GetSumTotalCart()
        {
            var sumTotal = 0.0;
            var cart = GetCartItems();

            foreach (var item in cart)
            {
                sumTotal += item.Price * item.Count;
            }

            return sumTotal;
        }
        public int NumItemsInCart()
        {
            var ch = new CookieHandler();
            return ch.NumItemsInCart();
        }
        [HttpPost]
        public int RemoveFromCart(int ProductId)
        {
            var ch = new CookieHandler();
            return ch.RemoveFromCart(ProductId);
        }
        public int UpdateCartProductCount(int ProductId, int Count)
        {
            var ch = new CookieHandler();
            return ch.UpdateCartProductCount(ProductId, Count);
        }
    }
}