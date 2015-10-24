using Newtonsoft.Json;
using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{
    public class CookieController : Controller
    {
        private const string SHOPPINGCART = "Shoppingcart";

        private IProductLogic _productBLL;
        private HttpCookie _shoppingcart; 

        public CookieController()
        {
            _productBLL = new ProductBLL();
            // _shoppingcart = this.Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
        }

        public CookieController(IProductLogic stub)
        {
            _productBLL = stub;
        }

        public ActionResult ShoppingCart(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.ShoppingCart = GetCartList();
            ViewBag.LoggedIn = LoginStatus();
            return View("Shoppingcart", "Home");
        }

        [HttpPost]
        public int AddToCart(int ProductId)
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            int numProduct;
            try
            {
                numProduct = Convert.ToInt32(_shoppingcart[ProductId.ToString()]);
                numProduct++;
            }
            catch (Exception)
            {
                numProduct = 1;
            }
            _shoppingcart[ProductId.ToString()] = numProduct.ToString();
            Response.Cookies.Add(_shoppingcart);


            return NumItemsInCart();
        }

        public ActionResult EmptyCart(string returnUrl)
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            _shoppingcart.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(_shoppingcart);

            return Redirect(returnUrl);
        }

        public string GetCart()
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            var cart = GetCartList();

            var jsonCart = JsonConvert.SerializeObject(cart);
            return jsonCart;
        }

        public List<CartItem> GetCartList()
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            var cookieValueList = _shoppingcart.Values;
            var productIdList = new List<int>();

            foreach (var cookieValue in cookieValueList)
            {
                var productId = Convert.ToInt32(cookieValue);
                try
                {
                    var count = Convert.ToInt32(_shoppingcart[productId.ToString()]);
                    if (count > 0)
                        productIdList.Add(productId);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            var productModelList = _productBLL.GetProducts(productIdList);

            var cartItemList = productModelList.Select(p => new CartItem()
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                Count = GetCount(p.ProductId),
                Price = p.Price
            }).ToList();

            return cartItemList;
        }

        public int GetCount(int productId)
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            var count = Convert.ToInt32(_shoppingcart[productId.ToString()]);
            return count;
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
            var list = GetCartList();
            var numItemsInCart = 0;
            foreach (var item in list)
            {
                var count = item.Count;
                numItemsInCart += count;
                
            }
            return numItemsInCart;
        }

        [HttpPost]
        public int RemoveFromCart(int ProductId)
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            _shoppingcart.Values[ProductId.ToString()] = null;
            Response.AppendCookie(_shoppingcart);

            return NumItemsInCart();
        }

        public int UpdateCartProductCount(int ProductId, int Count)
        {
            _shoppingcart = Request.Cookies[SHOPPINGCART] ?? new HttpCookie(SHOPPINGCART);
            _shoppingcart[ProductId.ToString()] = Count.ToString();
            Response.AppendCookie(_shoppingcart);

            return NumItemsInCart();

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