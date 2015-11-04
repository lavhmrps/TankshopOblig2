using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.Model;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class CategoryControllerTest : ControllerTestsBase
    {
        private CategoryController Controller { get; set; }

        private List<Category> Categories = new List<Category> {
            new Category { CategoryId = 1, Name = "test1"},
            new Category { CategoryId = 2, Name = "test2"},
            new Category { CategoryId = 3, Name = "test3"},
            new Category { CategoryId = 4, Name = "test4"}
        };

        private List<Product> Products = new List<Product> {
            new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
            new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
            new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
        };

        [TestInitialize]
        public new void Setup()
        {
            base.Setup();
            Services.Inject(new CategoryServiceStub(Categories));
            Services.Inject(new ProductServiceStub(Products));
            Controller = new CategoryController(Services);
        }

        [TestMethod]
        public void Index()
        {
            var viewResult = Controller.Index() as ViewResult;
            
            //Assert
            Assert.AreEqual(Categories.Count, viewResult.ViewBag.Categories.Count());

            foreach (Category c in viewResult.ViewBag.Categories)
            {
                CollectionAssert.Contains(Categories, c);
            }

            Assert.AreEqual("ListCategory", viewResult.ViewName);
        }

        [TestMethod]
        public void CreateCategory()
        {
            var expectedCategory = new Category { CategoryId = 1, Name = "test" };
            
            //Act
            var viewResult = Controller.CreateCategory() as ViewResult;
            var actualProductIDs = viewResult.ViewBag.ProductIDs;

            //Assert
            Assert.AreEqual(Products.Count, actualProductIDs.Count);
            for (int i = 0; i < actualProductIDs.Count; i++)
            {
                Assert.AreEqual(Products[i].Name, actualProductIDs[i].Text);
                Assert.AreEqual(Products[i].Id, actualProductIDs[i].Value);
            }

            Assert.AreEqual("", viewResult.ViewName);
        }


        [TestMethod]
        public void EditCategoryGoodInput()
        {

            //Arrange
            var controller = new CategoryController(Services);

            var expectedCategory = new Category { CategoryId = 1, Name = "test" };
            var allProducts = new List<Product> {
                new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { Id = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
            };

            List<SelectListItem> expectedProductIDs = new List<SelectListItem>();
            foreach (Product p in allProducts)
            {
                string productId = Convert.ToString(p.Id);
                expectedProductIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }
            
            //Act
            var viewResult = controller.EditCategory(1) as ViewResult;
            var actualCategory = controller.ViewBag.Category;
            var actualProductIDs = controller.ViewBag.ProductIDs;

            //Assert
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);

            Assert.AreEqual(expectedProductIDs.Count, actualProductIDs.Count);
            for (int i = 0; i < actualProductIDs.Count; i++)
            {
                Assert.AreEqual(expectedProductIDs[i].Text, actualProductIDs[i].Text);
                Assert.AreEqual(expectedProductIDs[i].Value, actualProductIDs[i].Value);
            }

            Assert.AreEqual("", viewResult.ViewName);
        }
        
        [TestMethod]
        public void DeleteCategoryGoodInput()
        {

            //Arrange
            int CategoryId = 2;

            Category expectedResult = new Category { CategoryId = 2, Name = "test" };

            //Act
            var viewResult = Controller.DeleteCategory(CategoryId) as ViewResult;
            
            //Assert
            Assert.AreEqual(expectedResult.CategoryId, viewResult.ViewBag.Category.CategoryId);
            Assert.AreEqual(expectedResult.Name, viewResult.ViewBag.Category.CategoryUrl);

            Assert.AreEqual("", viewResult.ViewName);
        }
        
        [TestMethod]
        public void DeleteCategoryNoCategoryFound()
        {

            //Arrange
            int CategoryId = -1;

            //Act
            var viewResult = Controller.DeleteCategory(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", Controller.ViewBag.Title);
            Assert.AreEqual("Could find an Category with the id: " + CategoryId, Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void CreateGoodInput()
        {
            var category = new CreateCategory
            {
                CategoryId = 1,
                Name = "categoryName"
            };

            //Act
            var viewResult = Controller.Create(category) as ViewResult;

            //Assert
            Assert.AreEqual("Success", Controller.ViewBag.Title);
            Assert.AreEqual("Category was added to the database", Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }
        
        [TestMethod]
        public void EditGoodInput()
        {

            //Arrange
            int categoryId = 1;
            string categoryName = "name";

            //Act
            var viewResult = Controller.Edit(new EditCategory { CategoryId = categoryId, Name = categoryName}) as ViewResult;

            //Assert
            Assert.AreEqual("Success", Controller.ViewBag.Title);
            Assert.AreEqual("Category was updated", Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }
        
        [TestMethod]
        public void EditInvalidCategoryId()
        {
            //Arrange
            int CategoryId = -1;

            //Act
            var viewResult = Controller.Edit(new EditCategory {CategoryId = CategoryId}) as ViewResult;

            //Assert
            Assert.AreEqual("Error", Controller.ViewBag.Title);
            Assert.AreEqual("Could not update the Category", Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }
        
        [TestMethod]
        public void DeleteGoodInput()
        {

            //Arrange
            int categoryId = 1;
            
            //Act
            var viewResult = Controller.Delete(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Success", Controller.ViewBag.Title);
            Assert.AreEqual("Category was deleted", Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteInvalidInput()
        {

            //Arrange
            int CategoryId = -1;

            //Act
            var viewResult = Controller.Delete(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", Controller.ViewBag.Title);
            Assert.AreEqual("Could not delete the Category", Controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

    }
}

