//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Nettbutikk.Model;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using Nettbutikk.Controllers;
//using Nettbutikk.BLL;
//using Nettbutikk.DAL;

//namespace TankShopEnhetstest
//{
//    [TestClass]
//    public class CategoryControllerTest
//    {

//        [TestMethod]
//        public void Index()
//        {
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            var expectedResults = new List<CategoryModel> {
//                new CategoryModel { CategoryId = 1, CategoryName = "test1"},
//                new CategoryModel { CategoryId = 2, CategoryName = "test2"},
//                new CategoryModel { CategoryId = 3, CategoryName = "test3"},
//                new CategoryModel { CategoryId = 4, CategoryName = "test4"}
//            };

//            var viewResult = controller.Index() as ViewResult;
//            var actualResults = controller.ViewBag.Categories;


//            //Assert
//            Assert.AreEqual(expectedResults.Count, actualResults.Count);

//            for (int i = 0; i < actualResults.Count; i++)
//            {
//                Assert.AreEqual(expectedResults[i].CategoryId, actualResults[i].CategoryId);
//                Assert.AreEqual(expectedResults[i].CategoryName, actualResults[i].CategoryName);
//            }


//            Assert.AreEqual("ListCategory", viewResult.ViewName);
//        }

//        [TestMethod]
//        public void CreateCategory()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

//            var expectedCategory = new CategoryModel { CategoryId = 1, CategoryName = "test" };
//            var allProducts = new List<ProductModel> {
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
//            };

//            var expectedProductIDs = new List<SelectListItem>();
//            foreach (var p in allProducts)
//            {
//                string productId = Convert.ToString(p.ProductId);
//                expectedProductIDs.Add(new SelectListItem { Text = productId, Value = productId });
//            }


//            //Act
//            var viewResult = controller.CreateCategory() as ViewResult;
//            var actualProductIDs = controller.ViewBag.ProductIDs;

//            //Assert
//            Assert.AreEqual(expectedProductIDs.Count, actualProductIDs.Count);
//            for (int i = 0; i < actualProductIDs.Count; i++)
//            {
//                Assert.AreEqual(expectedProductIDs[i].Text, actualProductIDs[i].Text);
//                Assert.AreEqual(expectedProductIDs[i].Value, actualProductIDs[i].Value);
//            }

//            Assert.AreEqual("", viewResult.ViewName);
//        }


//        [TestMethod]
//        public void EditCategoryGoodInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()) );

//            var expectedCategory = new CategoryModel { CategoryId = 1, CategoryName = "test" };
//            var allProducts = new List<ProductModel> {
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
//                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
//            };

//            var expectedProductIDs = new List<SelectListItem>();
//            foreach (var p in allProducts)
//            {
//                string productId = Convert.ToString(p.ProductId);
//                expectedProductIDs.Add(new SelectListItem { Text = productId, Value = productId });
//            }

//            string goodInput = "1";

//            //Act
//            var viewResult = controller.EditCategory(goodInput) as ViewResult;
//            var actualCategory = controller.ViewBag.Category;
//            var actualProductIDs = controller.ViewBag.ProductIDs;

//            //Assert
//            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
//            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
//            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);

//            Assert.AreEqual(expectedProductIDs.Count, actualProductIDs.Count);
//            for (int i = 0; i < actualProductIDs.Count; i++)
//            {
//                Assert.AreEqual(expectedProductIDs[i].Text, actualProductIDs[i].Text);
//                Assert.AreEqual(expectedProductIDs[i].Value, actualProductIDs[i].Value);
//            }

//            Assert.AreEqual("", viewResult.ViewName);
//        }


//        [TestMethod]
//        public void EditCategoryBadInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string badInput = "bad input";

//            //Act
//            var viewResult = controller.EditCategory(badInput) as ViewResult;


//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Invalid Category id: " + badInput, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }


//        [TestMethod]
//        public void EditCategoryNoCategoryFound()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string badCategoryId = "-1";

//            //Act
//            var viewResult = controller.EditCategory(badCategoryId) as ViewResult;


//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Couldnt find an Category with id: " + badCategoryId, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }


//        [TestMethod]
//        public void DeleteCategoryGoodInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "2";

//            var expectedResult = new CategoryModel { CategoryId = 2,  CategoryName= "test" };

//            //Act
//            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;
//            var actualResult = controller.ViewBag.Category;

//            //Assert
//            Assert.AreEqual(expectedResult.CategoryId, actualResult.CategoryId);
//            Assert.AreEqual(expectedResult.CategoryName, actualResult.CategoryName);

//            Assert.AreEqual("", viewResult.ViewName);
//        }

//        [TestMethod]
//        public void DeleteCategoryBadInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "bad input";

//            //Act
//            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }

//        [TestMethod]
//        public void DeleteCategoryNoCategoryFound()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "-1";

//            //Act
//            var viewResult = controller.DeleteCategory(CategoryId) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Could find an Category with the id: " + CategoryId, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }


//        [TestMethod]
//        public void CreateGoodInput()
//        {
//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryName = "test";
//            //Act
//            var viewResult = controller.Create(CategoryName) as ViewResult;

//            //Assert
//            Assert.AreEqual("Success", controller.ViewBag.Title);
//            Assert.AreEqual("Category was added to the database", controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }

//        [TestMethod]
//        public void CreateBadInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryName = "invalid";

//            //Act
//            var viewResult = controller.Create(CategoryName) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Invalid product id", controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }

//        [TestMethod]
//        public void CreateInvalidProductId()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryName = "test";

//            //Act
//            var viewResult = controller.Create(CategoryName) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Could not add the Category to the database", controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }

//        [TestMethod]
//        public void EditGoodInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "1";
//            string Categoryname = "test";

//            //Act
//            var viewResult = controller.Edit(CategoryId, Categoryname) as ViewResult;

//            //Assert
//            Assert.AreEqual("Success", controller.ViewBag.Title);
//            Assert.AreEqual("Category was updated", controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }


//        [TestMethod]
//        public void EditBadCategoryId()
//        {

//            //Arrange
//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            var CategoryId = "-1";
//            string Categoryname = "test";

//            //Act
//            var viewResult = controller.Edit(CategoryId, Categoryname) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }


//        [TestMethod]
//        public void DeleteGoodInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "1";            

//            //Act
//            var viewResult = controller.Delete(CategoryId) as ViewResult;

//            //Assert
//            Assert.AreEqual("Success", controller.ViewBag.Title);
//            Assert.AreEqual("Category was deleted", controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }

//        [TestMethod]
//        public void DeleteBadInput()
//        {

//            //Arrange
//            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
//            string CategoryId = "-1";

//            //Act
//            var viewResult = controller.Delete(CategoryId) as ViewResult;

//            //Assert
//            Assert.AreEqual("Error", controller.ViewBag.Title);
//            Assert.AreEqual("Invalid Category id: " + CategoryId, controller.ViewBag.Message);
//            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

//        }
//    }
//}
