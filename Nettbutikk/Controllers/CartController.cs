using Newtonsoft.Json;
using Nettbutikk.Models;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.ShoppingCart = GetCartList();
            ViewBag.LoggedIn = Session["LoggedIn"] ?? false;
            return View("Shoppingcart");
        }

        [HttpPost]
        public int AddToCart(int ProductId)
        {
            var ch = new CookieHandler();
            return ch.AddToCart(ProductId);
        }
        public void EmptyCart()
        {
            var ch = new CookieHandler();
            ch.EmptyCart();
        }
        public string GetCart()
        {
            var cart = GetCartList();

            var jsonCart = JsonConvert.SerializeObject(cart);
            return jsonCart;
        }
        public List<CartItem> GetCartList()
        {
            var ch = new CookieHandler();
            var productIdList = ch.GetCartProductIds();
            var productModelList = Services.Products.GetAll(productIdList);

            var cartItemList = productModelList.Select(p => new CartItem()
            {
                ProductId = p.Id,
                Name = p.Name,
                Count = ch.GetCount(p.Id),
                Price = p.Price
            }).ToList();

            return cartItemList;
        }
        public double GetSumTotalCart()
        {
            var sumTotal = 0.0;
            var cart = GetCartList();

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