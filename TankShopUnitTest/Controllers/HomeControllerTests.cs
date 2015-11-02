using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Models;
using System.Web.Mvc;
using Nettbutikk.Model;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests : ControllerTestsBase
    {
        private Category[] categories =
        {

        };

        private Product[] products =
        {

        };

        public HomeController Controller { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            base.Setup();

            Services.Configure(new CategoryServiceStub(categories));
            Services.Configure(new ProductServiceStub(products));
            Controller = new HomeController(Services);
        }

        [TestMethod]
        public void IndexTest()
        {
            var result = Controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(HomeView));
        }

        [TestMethod]
        public void CategoryTest()
        {
            var categoryId = 1;
            var result = Controller.Category(categoryId) as ViewResult;
            var model = result.Model as HomeCategoryView;

            Assert.IsInstanceOfType(result.Model, typeof(HomeCategoryView));
            Assert.IsNotNull(model.Category);
            Assert.Equals(model.Category.CategoryId, categoryId);
        }
    }
}