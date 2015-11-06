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
        [TestMethod]
        public void OrderPartial_List()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            // Act
            var result = (PartialViewResult)Controller.OrdersPartial(1);

            // Assert
            Assert.AreEqual("", result.ViewName);
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
            var expectedResult = 1.0;

            // Act
            var result = Controller.GetOrderSumTotal(orderId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetOrderSumTotal_Bad_OrderId()
        {
            // Arrange
            var Controller = new OrderController(new OrderBLL(new OrderRepoStub()));

            var orderId = 0;
            var expectedResult = 0.0;

            // Act
            var result = Controller.GetOrderSumTotal(orderId);

            // Assert
            Assert.AreEqual(expectedResult, result);
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
