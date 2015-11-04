using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Controllers;
using Oblig1_Nettbutikk.DAL;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TankShopUnitTest
{
    [TestClass]
    public class CustomerControllerTest
    {

        [TestMethod]
        public void Customer_Administration_ok()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController();
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = true;

            // Act
            var result = (ViewResult)Controller.Index();

            // Assert
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void Customer_Administration_No_AdminSession()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController();
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = null;

            // Act
            var result = (RedirectToRouteResult)Controller.Index();

            // Assert
            Assert.AreEqual("", result.RouteName);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void Customer_Administration_Not_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController();
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = false;

            // Act
            var result = (RedirectToRouteResult)Controller.Index();

            // Assert
            Assert.AreEqual("", result.RouteName);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void Admin_ShowCustomer_ok()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = true;

            // Act
            var result = (ViewResult)Controller.ShowCustomer(1, "");

            // Assert
            Assert.AreEqual("Administration_Customer", result.ViewName);
        }

        [TestMethod]
        public void Admin_ShowCustomer_No_AdminSession()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = null;

            // Act
            var result = (RedirectToRouteResult)Controller.ShowCustomer(1, "");

            // Assert
            Assert.AreEqual("", result.RouteName);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void Admin_ShowCustomer_Not_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            SessionMock.InitializeController(Controller);
            Controller.Session["Admin"] = false;

            // Act
            var result = (RedirectToRouteResult)Controller.ShowCustomer(1, "");

            // Assert
            Assert.AreEqual("", result.RouteName);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }


        [TestMethod]
        public void CustomerlistPartial_List()
        {
            // Arrange
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));

            var customerView = new CustomerView()
            {
                CustomerId = 1,
                Email = "ole@gmail.com",
                Firstname = "Ole",
                Lastname = "Olsen",
                Address = "Persveien 5",
                Zipcode = "0123",
                City = "Oslo"
            };
            var expectedResult = new List<CustomerView>();
            expectedResult.Add(customerView);
            expectedResult.Add(customerView);
            expectedResult.Add(customerView);

            // Act
            var result = (PartialViewResult)Controller.CustomerlistPartial();
            var modelresult = (List<CustomerView>)result.Model;

            // Assert
            Assert.AreEqual("", result.ViewName);
            for (var i = 0; i < modelresult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].CustomerId, modelresult[i].CustomerId);
                Assert.AreEqual(expectedResult[i].Email, modelresult[i].Email);
                Assert.AreEqual(expectedResult[i].Firstname, modelresult[i].Firstname);
                Assert.AreEqual(expectedResult[i].Lastname, modelresult[i].Lastname);
                Assert.AreEqual(expectedResult[i].Address, modelresult[i].Address);
                Assert.AreEqual(expectedResult[i].Zipcode, modelresult[i].Zipcode);
                Assert.AreEqual(expectedResult[i].City, modelresult[i].City);
            }
        }

        [TestMethod]
        public void OrderPartial_List()
        {
            // Arrange
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));

            // Act
            var result = (PartialViewResult)Controller.OrdersPartial(1);

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void UpdateCustomer_ok()
        {
            // Arrange
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            var customerView = new CustomerView()
            {
                CustomerId = 1,
                Email = "ole@gmail.com",
                Firstname = "Ole",
                Lastname = "Olsen",
                Address = "Persveien 5",
                Zipcode = "0123",
                City = "Oslo"
            };

            // Act
            var result = (bool)Controller.UpdateCustomerInfo(customerView);

            // Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void UpdateCustomer_modelerror()
        {
            // Arrange
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            var customerView = new CustomerView()
            {
                CustomerId = 1,
                Email = "",
                Firstname = "Ole",
                Lastname = "Olsen",
                Address = "Persveien 5",
                Zipcode = "0123",
                City = "Oslo"
            };

            // Act
            var result = (bool)Controller.UpdateCustomerInfo(customerView);

            // Assert
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void DeleteCustomer_ok()
        {
            // Arrange
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            var email = "ole@gmail.com";

            // Act
            var result = (bool)Controller.DeleteCustomer(email);

            // Assert
            Assert.IsTrue(result);


        }

        [TestMethod]
        public void DeleteCustomer_No_EmailSession()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var Controller = new CustomerController(new CustomerBLL(new CustomerRepoStub()));
            SessionMock.InitializeController(Controller);
            Controller.Session["Email"] = false;
            var email = "ole@gmail.com";

            // Act
            var result = (bool)Controller.DeleteCustomer(email);

            // Assert
            Assert.IsFalse(result);


        }

       
    }
}
