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
    }
}
