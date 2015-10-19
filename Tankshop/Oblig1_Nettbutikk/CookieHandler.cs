using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk
{
    public class CookieHandler
    {
        public static List<CartItem> GetCartList(Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"] ?? new HttpCookie("Shoppingcart");
            var list = cookie.Values;
            var cart = new List<CartItem>();

            using (var db = new WebShopModel())
            {
                foreach (var c in list)
                {
                    try
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
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }

            return cart;
        }

        public static void EmptyCart(Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"];
            cookie.Expires = DateTime.Now.AddDays(-1d);
            controller.Response.Cookies.Add(cookie);

        }

        public static int AddToCart(Controller controller, int ProductId)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"] ?? new HttpCookie("Shoppingcart");
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
            controller.Response.Cookies.Add(cookie);

            var list = cookie.Values;
            var numItemsInCart = 0;
            foreach (var c in list)
            {
                try
                {
                    var count = Convert.ToInt32(cookie[c.ToString()]);
                    numItemsInCart += count;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return numItemsInCart;
        }

        public static int NumItemsInCart(Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"];
            if (cookie == null)
                return 0;

            var list = cookie.Values;
            var numItemsInCart = 0;
            foreach (var c in list)
            {
                try
                {
                    var count = Convert.ToInt32(cookie[c.ToString()]);
                    numItemsInCart += count;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return numItemsInCart;
        }

        public static double GetSumTotalCart(Controller controller)
        {
            var sumTotal = 0.0;
            var cart = GetCartList(controller);

            foreach (var item in cart)
            {
                sumTotal += item.Price * item.Count;
            }

            return sumTotal;
        }

        public static int UpdateCartProductCount(int ProductId, int Count, Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"];
            cookie[ProductId.ToString()] = Count.ToString();
            controller.Response.AppendCookie(cookie);

            return NumItemsInCart(controller);

        }

        public static int RemoveFromCart(int ProductId, Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"];
            cookie.Values[ProductId.ToString()] = null;
            controller.Response.AppendCookie(cookie);

            //GetCart(this);

            return NumItemsInCart(controller);
        }
    }
}