using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Models;
using System.Collections;
using System.Web.Mvc;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class AdminProductsControllerTests : ProductControllerTests
    {
        private AdminProductsController Controller;

        [TestInitialize]
        public new void Setup()
        {
            base.Setup();

            Services.Inject(new ProductServiceStub(Products));
            Services.Inject(new CategoryServiceStub(Categories));

            Controller = new AdminProductsController(Services);
        }

        [TestMethod]
        public void HttpGet_CreateTest()
        {
            var result = Controller.Create() as ViewResult;

            Assert.IsNotNull(result.Model);

            var model = result.Model as CreateProduct;

            Assert.IsNotNull(model.Categories);

            CollectionAssert.AreEquivalent(Categories, model.Categories as ICollection);
        }

        [TestMethod]
        public void HttpPost_CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}