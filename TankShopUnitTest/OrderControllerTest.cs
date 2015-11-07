using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Nettbutikk.BLL;
using Nettbutikk.Controllers;
using Nettbutikk.DAL;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TankShopUnitTest
{
    [TestClass]
    public class OrderControllerTest
    {
        private OrderlineModel orderlineModel;
        private List<OrderlineModel> orderlineModels;
        private OrderModel orderModel;
        private List<OrderModel> orderModels;

        private ProductModel productModel;
        private List<ProductModel> productModels;

        private readonly int ALL_ORDERS = 0;
        private readonly int CUSTOMER_ORDERS = 1;

        public OrderControllerTest()
        {
            orderlineModel = new OrderlineModel()
            {
                Count = 1,
                OrderId = 1,
                OrderlineId = 1,
                ProductId = 1
            };

            orderlineModels = new List<OrderlineModel>();
            orderlineModels.Add(orderlineModel);
            orderlineModels.Add(orderlineModel);
            orderlineModels.Add(orderlineModel);

            orderModel = new OrderModel()
            {
                CustomerId = 1,
                Date = new DateTime(2015, 1, 1),
                OrderId = 1,
                Orderlines = orderlineModels
            };

            orderModels = new List<OrderModel>();
            orderModels.Add(orderModel);
            orderModels.Add(orderModel);
            orderModels.Add(orderModel);

            productModel = new ProductModel
            {
                ProductId = 1,
                ProductName = "tank",
                Price = 150,
                Stock = 5,
                Description = "blows things up",
                CategoryId = 1
            };

            productModels = new List<ProductModel>();
            productModels.Add(productModel);
            productModels.Add(productModel);
            productModels.Add(productModel);
        }

        [TestMethod]
        public void OrderPartial_List_All_Orders()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            var expOrderViews = new List<OrderView>();
            var expProductViews = new List<ProductView>();
            var expViewName = "";
            var expTitle = "Ordreadministrasjon - Alle ordre";

            foreach (var o in orderModels)
            {
                var order = new OrderView();
                order.Date = o.Date;
                order.OrderId = o.OrderId;
                order.CustomerId = o.CustomerId;
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
                expOrderViews.Add(order);
            }

            foreach (var productModel in productModels)
            {
                var productview = new ProductView()
                {
                    ProductId = productModel.ProductId,
                    ProductName = productModel.ProductName,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    Stock = productModel.Stock,
                    CategoryId = productModel.CategoryId
                };
                expProductViews.Add(productview);
            }

            // Act
            var result = Controller.OrdersPartial(ALL_ORDERS);

            var viewBagOrders = result.ViewBag.Orders;
            var viewBagProducts = result.ViewBag.Products;
            var viewBagTitle = result.ViewBag.Title;

            //// Assert
            Assert.AreEqual(expViewName, result.ViewName);

            for(int i=0; i < viewBagOrders.Count;i++)
            {
                Assert.AreEqual(expOrderViews[i].OrderId, viewBagOrders[i].OrderId);
                Assert.AreEqual(expOrderViews[i].CustomerId, viewBagOrders[i].CustomerId);
                Assert.AreEqual(expOrderViews[i].Date, viewBagOrders[i].Date);
                for (int j = 0; j < expOrderViews[i].Orderlines.Count; j++)
                {
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Count, viewBagOrders[i].Orderlines[j].Count);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].OrderlineId, viewBagOrders[i].Orderlines[j].Count);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.ProductId, viewBagOrders[i].Orderlines[j].Product.ProductId);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.ProductName, viewBagOrders[i].Orderlines[j].Product.ProductName);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.Price, viewBagOrders[i].Orderlines[j].Product.Price);
                }
            }

            for (int i = 0; i < viewBagProducts.Count; i++)
            {
                Assert.AreEqual(expProductViews[i].ProductId, viewBagProducts[i].ProductId);
                Assert.AreEqual(expProductViews[i].ProductName, viewBagProducts[i].ProductName);
                Assert.AreEqual(expProductViews[i].Price, viewBagProducts[i].Price);
                Assert.AreEqual(expProductViews[i].Description, viewBagProducts[i].Description);
                Assert.AreEqual(expProductViews[i].Stock, viewBagProducts[i].Stock);
                Assert.AreEqual(expProductViews[i].CategoryId, viewBagProducts[i].CategoryId);
            }

            Assert.AreEqual(expTitle, viewBagTitle);
        }

        [TestMethod]
        public void OrderPartial_List_Customer_Orders()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            var expOrderViews = new List<OrderView>();
            var expProductViews = new List<ProductView>();
            var expViewName = "";
            var expTitle = "Ordreadministrasjon - Kunde";

            foreach (var o in orderModels)
            {
                var order = new OrderView();
                order.Date = o.Date;
                order.OrderId = o.OrderId;
                order.CustomerId = o.CustomerId;
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
                expOrderViews.Add(order);
            }

            foreach (var productModel in productModels)
            {
                var productview = new ProductView()
                {
                    ProductId = productModel.ProductId,
                    ProductName = productModel.ProductName,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    Stock = productModel.Stock,
                    CategoryId = productModel.CategoryId
                };
                expProductViews.Add(productview);
            }

            // Act
            var result = Controller.OrdersPartial(CUSTOMER_ORDERS);

            var viewBagOrders = result.ViewBag.Orders;
            var viewBagProducts = result.ViewBag.Products;
            var viewBagTitle = result.ViewBag.Title;

            //// Assert
            Assert.AreEqual(expViewName, result.ViewName);

            for (int i = 0; i < viewBagOrders.Count; i++)
            {
                Assert.AreEqual(expOrderViews[i].OrderId, viewBagOrders[i].OrderId);
                Assert.AreEqual(expOrderViews[i].CustomerId, viewBagOrders[i].CustomerId);
                Assert.AreEqual(expOrderViews[i].Date, viewBagOrders[i].Date);
                for (int j = 0; j < expOrderViews[i].Orderlines.Count; j++)
                {
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Count, viewBagOrders[i].Orderlines[j].Count);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].OrderlineId, viewBagOrders[i].Orderlines[j].Count);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.ProductId, viewBagOrders[i].Orderlines[j].Product.ProductId);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.ProductName, viewBagOrders[i].Orderlines[j].Product.ProductName);
                    Assert.AreEqual(expOrderViews[i].Orderlines[j].Product.Price, viewBagOrders[i].Orderlines[j].Product.Price);
                }
            }

            for (int i = 0; i < viewBagProducts.Count; i++)
            {
                Assert.AreEqual(expProductViews[i].ProductId, viewBagProducts[i].ProductId);
                Assert.AreEqual(expProductViews[i].ProductName, viewBagProducts[i].ProductName);
                Assert.AreEqual(expProductViews[i].Price, viewBagProducts[i].Price);
                Assert.AreEqual(expProductViews[i].Description, viewBagProducts[i].Description);
                Assert.AreEqual(expProductViews[i].Stock, viewBagProducts[i].Stock);
                Assert.AreEqual(expProductViews[i].CategoryId, viewBagProducts[i].CategoryId);
            }

            Assert.AreEqual(expTitle, viewBagTitle);
        }

        [TestMethod]
        public void UpdateOrderline_Ok()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = true;
            var OrderlineId = 1;
            var ProductId = 1;
            var Count = 1;

            // Act
            var result = Controller.UpdateOrderline(OrderlineId, ProductId, Count);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateOrderline_Not_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = false;
            var OrderlineId = 1;
            var ProductId = 1;
            var Count = 1;

            // Act
            var result = Controller.UpdateOrderline(OrderlineId, ProductId, Count);

            // Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void UpdateOrderline_No_AdminSession()
        {

            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = null;
            var OrderlineId = 1;
            var ProductId = 1;
            var Count = 1;

            // Act
            var result = Controller.UpdateOrderline(OrderlineId, ProductId, Count);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateOrderline_Modelerror()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = true;
            var OrderlineId = 0;
            var ProductId = 1;
            var Count = 1;

            // Act
            var result = Controller.UpdateOrderline(OrderlineId, ProductId, Count);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetOrderSumTotal_ok()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            var orderId = 1;
            var expResult = 1.0;

            // Act
            var result = Controller.GetOrderSumTotal(orderId);

            // Assert
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void GetOrderSumTotal_Bad_OrderId()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            var orderId = 0;
            var expResult = 0.0;

            // Act
            var result = Controller.GetOrderSumTotal(orderId);

            // Assert
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void DeleteOrder_ok()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = true;
            var orderId = 1;

            // Act
            var result = Controller.DeleteOrder(orderId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteOrder_No_AdminSession()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = null;
            var orderId = 1;

            // Act
            var result = Controller.DeleteOrder(orderId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteOrder_Not_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = false;
            var orderId = 1;

            // Act
            var result = Controller.DeleteOrder(orderId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteOrder_Bad_OrderId()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));
            SessionMock.InitializeController(Controller);

            Controller.Session["Admin"] = true;
            var orderId = 0;

            // Act
            var result = Controller.DeleteOrder(orderId);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
