using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Models;
using System.Web.Mvc;
using Nettbutikk.Model;
using System.Collections.Generic;
using System.Collections;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests : ControllerTestsBase
    {
        private List<Category> Categories = new List<Category>
        {

        };

        private List<Product> Products = new List<Product>
        {

        };

        public HomeController Controller { get; private set; }

        [TestInitialize]
        public new void Setup()
        {
            base.Setup();

            Services.Inject(new CategoryServiceStub(Categories));
            Services.Inject(new ProductServiceStub(Products));
            Controller = new HomeController(Services);
            Controller.ControllerContext = CreateContextMock();
        }

        [TestMethod]
        public void IndexTest()
        {
            var result = Controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(HomeView));

            var model = result.Model as HomeView;

            CollectionAssert.AreEquivalent(Products, model.Products as ICollection);
            CollectionAssert.AreEquivalent(Categories, model.Categories as ICollection);
        }

        [TestMethod]
        public void CategoryTest()
        {
            var categoryId = 1;
            var result = Controller.Category(categoryId) as ViewResult;
            
            Assert.IsInstanceOfType(result.Model, typeof(HomeCategoryView));

            var model = result.Model as HomeCategoryView;

            Assert.IsNotNull(model.Category);
            Assert.Equals(model.Category.CategoryId, categoryId);
        }
    }
}