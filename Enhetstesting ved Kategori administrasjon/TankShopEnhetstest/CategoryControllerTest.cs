using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Category;
using BLL.Category;
using Oblig1_Nettbutikk.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Controllers;
using DAL.Category;
using BLL.Category;

namespace TankShopEnhetstest
{
    [TestClass]
    public class CategoryControllerTest
    {
        
        [TestMethod]
        public void Index()
        {

            
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            var expectedResults = new List<Category> {
                new Category { CategoryId = 1, ProductId = 1, CategoryName = "test1"},
                new Category { CategoryId = 2, ProductId = 2, CategoryName = "test2"},
                new Category { CategoryId = 3, ProductId = 3, CategoryName = "test3"},
                new Category { CategoryId = 4, ProductId = 4, CategoryName = "test4"}
            };


          
            var viewResult = controller.Index() as ViewResult;
            var actualResults = controller.ViewBag.Categories;


            //Assert
            Assert.AreEqual(expectedResults.Count, actualResults.Count);

            for (int i = 0; i < actualResults.Count; i++)
            {
                Assert.AreEqual(expectedResults[i].CategoryId, actualResults[i].CategoryId);
                Assert.AreEqual(expectedResults[i].ProductId, actualResults[i].ProductId);
                Assert.AreEqual(expectedResults[i].CategoryName, actualResults[i].CategoryName);
            }


            Assert.AreEqual("ListCategory", viewResult.ViewName);
        }

        [TestMethod]
        public void CreateCategory()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()),
                new Oblig1_Nettbutikk.BLL.ProductBLL(new Oblig1_Nettbutikk.DAL.ProductRepoStub()));

            var expectedCategory = new Category { CategoryId = 1, ProductId = 1, CategoryName = "test" };
            var allProducts = new List<Product> {
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
            };

            List<SelectListItem> expectedProductIDs = new List<SelectListItem>();
            foreach (Product p in allProducts)
            {
                string productId = Convert.ToString(p.ProductId);
                expectedProductIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }


            //Act
            var viewResult = controller.CreateCategory() as ViewResult;
            var actualProductIDs = controller.ViewBag.ProductIDs;

            //Assert
            Assert.AreEqual(expectedProductIDs.Count, actualProductIDs.Count);
            for (int i = 0; i < actualProductIDs.Count; i++)
            {
                Assert.AreEqual(expectedProductIDs[i].Text, actualProductIDs[i].Text);
                Assert.AreEqual(expectedProductIDs[i].Value, actualProductIDs[i].Value);
            }

            Assert.AreEqual("", viewResult.ViewName);
        }


        [TestMethod]
        public void EditCategoryGoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()),
                new Oblig1_Nettbutikk.BLL.ProductBLL(new Oblig1_Nettbutikk.DAL.ProductRepoStub()));

            var expectedCategory = new Category { CategoryId = 1, ProductId = 1, CategoryName = "test" };
            var allProducts = new List<Product> {
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
            };

            List<SelectListItem> expectedProductIDs = new List<SelectListItem>();
            foreach (Product p in allProducts)
            {
                string productId = Convert.ToString(p.ProductId);
                expectedProductIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            string goodInput = "1";

            //Act
            var viewResult = controller.EditCategory(goodInput) as ViewResult;
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
        public void EditCategoryBadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string badInput = "bad input";

            //Act
            var viewResult = controller.EditCategory(badInput) as ViewResult;


            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid Category id: " + badInput, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void EditCategoryNoCategoryFound()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string badCategoryId = "-1";

            //Act
            var viewResult = controller.EditCategory(badCategoryId) as ViewResult;


            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Couldnt find an Category with id: " + badCategoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void DeleteCategoryGoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "2";

            Category expectedResult = new Category { CategoryId = 2, ProductId = 1, CategoryUrl = "test" };

            //Act
            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;
            var actualResult = controller.ViewBag.Category;

            //Assert
            Assert.AreEqual(expectedResult.CategoryId, actualResult.CategoryId);
            Assert.AreEqual(expectedResult.ProductId, actualResult.ProductId);
            Assert.AreEqual(expectedResult.CategoryUrl, actualResult.CategoryUrl);

            Assert.AreEqual("", viewResult.ViewName);
        }

        [TestMethod]
        public void DeleteCategoryBadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "bad input";

            //Act
            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteCategoryNoCategoryFound()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "-1";

            //Act
            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could find an Category with the id: " + CategoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void CreateGoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string productId = "1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Create(productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was added to the database", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void CreateBadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string productId = "bad input";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Create(productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid product id", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void CreateInvalidProductId()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string productId = "-1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Create(productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not add the Category to the database", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditGoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "1";
            string productId = "1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Edit(CategoryId, productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was updated", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void EditBadCategoryId()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "bad";
            string productId = "1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Edit(CategoryId, productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditBadProductId()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "1";
            string productId = "bad";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Edit(CategoryId, productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid product id: " + productId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditInvalidCategoryId()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "-1";
            string productId = "1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Edit(CategoryId, productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not update the Category", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditInvalidProductId()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "1";
            string productId = "-1";
            string CategoryUrl = "url";

            //Act
            var viewResult = controller.Edit(CategoryId, productId, CategoryUrl) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not update the Category", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);
        }


        [TestMethod]
        public void DeleteGoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "1";

            Category expectedResult = new Category { CategoryId = 1, ProductId = 1, CategoryUrl = "test" };

            //Act
            var viewResult = controller.Delete(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was deleted", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteBadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "bad input";

            //Act
            var viewResult = controller.Delete(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteInvalidInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string CategoryId = "-1";

            //Act
            var viewResult = controller.Delete(CategoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not delete the Category", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

    }
}

