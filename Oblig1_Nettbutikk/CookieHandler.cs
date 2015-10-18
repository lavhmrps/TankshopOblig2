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
        public List<CartItem> GetCartList(Controller controller)
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

        internal void EmptyCart(Controller controller)
        {
            var cookie = controller.Request.Cookies["Shoppingcart"];
            cookie.Expires = DateTime.Now.AddDays(-1d);
            controller.Response.Cookies.Add(cookie);

        }
    }
}