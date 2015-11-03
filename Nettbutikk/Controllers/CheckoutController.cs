using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CheckoutController : BaseController
    {
        private IOrderLogic _orderBLL;

        public CheckoutController()
            : base()
        {
            _orderBLL = new OrderBLL();
        }

        public CheckoutController(IOrderLogic stub)
        {
            _orderBLL = stub;
        }

        public ActionResult Checkout()
        {
            if (Session["LoggedIn"] != null)
            {
                if ((bool)Session["LoggedIn"])
                {
                    var ch = new CookieHandler();

                    var Email = (string)Session["Email"];
                    var pidList = ch.GetCartProductIds();
                    var productModelList = Services.Products.GetAll(pidList);

                    var cart = productModelList.Select(p => new CartItem()
                    {
                        ProductId = p.Id,
                        Name = p.Name,
                        Count = ch.GetCount(p.Id),
                        Price = p.Price
                    }).ToList();

                    var customerModel = new AccountBLL().GetCustomer(Email);
                    var customer = new CustomerView()
                    {
                        Firstname = customerModel.Firstname,
                        Lastname = customerModel.Lastname,
                        Address = customerModel.Address,
                        Zipcode = customerModel.Zipcode,
                        City = customerModel.City,
                        Id = customerModel.CustomerId,
                        Email = customerModel.Email

                    };

                    ViewBag.Cart = cart;
                    ViewBag.Customer = customer;
                    ViewBag.LoggedIn = LoginStatus();

                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PlaceOrder(string returnUrl)
        {
            if (Session["LoggedIn"] != null)
            {
                if ((bool)Session["LoggedIn"])

                {
                    var ch = new CookieHandler();

                    var productIdList = ch.GetCartProductIds();
                    var productModelList = Services.Products.GetAll(productIdList);

                    var cart = productModelList.Select(product => new CartItem()
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Count = ch.GetCount(product.Id),
                        Price = product.Price
                    }).ToList();
                    
                    var order = new Order();
                    var orderlines = new List<Orderline>();

                    foreach (var item in cart)
                    {
                        orderlines.Add(new Orderline()
                        {
                            Count = item.Count,
                            ProductId = item.ProductId
                        });
                    }
                    order.Orderlines = orderlines;
                    order.CustomerId = new AccountBLL().GetCustomer(Session["Email"] as string).CustomerId;
                    order.Date = DateTime.Now;
                    var OrderId = _orderBLL.PlaceOrder(order);

                    if (OrderId > 0)
                    {
                        ch.EmptyCart();
                                               
                        ViewBag.LoggedIn = (bool)Session["LoggedIn"];
                        ViewBag.Reciept = GetReciept(OrderId);

                        return View("GetReciept");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
           

        public OrderView GetReciept(int OrderId)
        {
           
            Order reciept = _orderBLL.GetReciept(OrderId);

            var orderlines = new List<OrderlineView>();
            foreach(var item in reciept.Orderlines)
            {
                var product = new ProductView()
                {
                    Id = item.ProductId,
                    Name = item.ProductName,
                    Price = item.ProductPrice,

                };

                orderlines.Add(new OrderlineView()
                {
                    OrderlineId = item.OrderlineId,
                    Count = item.Count,
                    Product = product

                });
            }

            OrderView orderView = new OrderView()
            {
                OrderId = reciept.OrderId,
                Date = reciept.Date,
                Orderlines = orderlines,
            };

            return orderView ;
        }
    }
}