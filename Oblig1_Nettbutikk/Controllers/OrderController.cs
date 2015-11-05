using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{
    public class OrderController : Controller
    {

        private IOrderLogic _orderBLL;

        public OrderController()
        {
            _orderBLL = new OrderBLL();
        }

        public OrderController(IOrderLogic stub)
        {
            _orderBLL = stub;
        }

        [ChildActionOnly]
        public PartialViewResult OrdersPartial(int CustomerId)
        {
            List<OrderModel> orderModels;
            if (CustomerId > 0)
                orderModels = _orderBLL.GetCustomer(CustomerId).Orders;
            else
                orderModels = _orderBLL.GetAllOrders();

            var orderViews = new List<OrderView>();

            foreach (var o in orderModels)
            {
                var order = new OrderView();
                order.Date = o.Date;
                order.OrderId = o.OrderId;
                order.Orderlines = new List<OrderlineView>();

                foreach (var l in o.Orderlines)
                {
                    var orderline = new OrderlineView();
                    orderline.Count = l.Count;
                    orderline.OrderlineId = l.OrderlineId;
                    orderline.Product = new ProductView()
                    {
                        Price = l.ProductPrice,
                        ProductId = l.ProductId,
                        ProductName = l.ProductName
                    };

                    order.Orderlines.Add(orderline);
                }
                orderViews.Add(order);
            }

            var productModels = _orderBLL.GetAllProducts();
            var productViews = new List<ProductView>();

            foreach (var productModel in productModels)
            {
                var productview = new ProductView()
                {
                    ProductId = productModel.ProductId,
                    ProductName = productModel.ProductName,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    Stock = productModel.Stock,
                    ImageUrl = productModel.ImageUrl,
                    CategoryName = productModel.CategoryName
                };
                productViews.Add(productview);
            }

            string Title = CustomerId == 0 ? "Ordreadministrasjon - Alle ordre" : "Ordreadministrasjon - Kunde";

            ViewBag.Orders = orderViews;
            ViewBag.Products = productViews;
            ViewBag.Title = Title;


            return PartialView();
        }
        [HttpPost]
        public bool UpdateOrderline(int OrderlineId, int ProductId, int Count)
        {
            var orderlineModel = new OrderlineModel()
            {
                Count = Count,
                OrderlineId = OrderlineId,
                ProductId = ProductId
            };

            if (_orderBLL.UpdateOrderline(orderlineModel))
            {
                return true;
            }
            return false;
        }

        public double GetOrderSumTotal(int OrderId)
        {
            return _orderBLL.GetOrderSumTotal(OrderId);

        }

        [HttpPost]
        public bool DeleteOrder(int OrderId)
        {
            return _orderBLL.DeleteOrder(OrderId);
        }
    }
}