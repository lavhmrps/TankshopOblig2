using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Category;
using DAL.Category;
using MvcContrib.TestHelper;
using Oblig1_Nettbutikk.Controllers;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Model;

namespace TankShopUnitTest
{
    [TestClass]
    public class CategoryControllerTest
    {

        [TestMethod]
        public void Category_Index() {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            var expectedCategories = new List<Category> {
                new Category { CategoryId = 1, Name = "test name 1"},
                new Category { CategoryId = 2, Name = "test name 2"},
                new Category { CategoryId = 3, Name = "test name 3"},
                new Category { CategoryId = 4, Name = "test name 4"}
            };


            //Act
            var viewResult = controller.Index() as ViewResult;
            var actualCategories = controller.ViewBag.Categories;


            //Assert
            Assert.AreEqual(expectedCategories.Count, actualCategories.Count);
            for (int i = 0; i < actualCategories.Count; i++)
            {
                Assert.AreEqual(expectedCategories[i].CategoryId, actualCategories[i].CategoryId);
                Assert.AreEqual(expectedCategories[i].Name, actualCategories[i].Name);
            }

            Assert.AreEqual("ListCategory",viewResult.ViewName);

        }

        [TestMethod]
        public void Category_CreateCategory()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            //Act
            var viewResult = controller.CreateCategory() as ViewResult;


            //Assert
            Assert.AreEqual("",viewResult.ViewName);
        }


        [TestMethod]
        public void Category_EditCategory_GoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "2";
            var expectedCategory = new Category { CategoryId = 2, Name = "test name"};

            //Act
            var viewResult = controller.EditCategory(categoryId) as ViewResult;
            var actualCategory = controller.ViewBag.Category;


            //Assert
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
            Assert.AreEqual(expectedCategory.Name, actualCategory.Name);

            Assert.AreEqual("", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_EditCategory_BadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "123abc";

            //Act
            var viewResult = controller.EditCategory(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid category id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_EditCategory_InvalidInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "-1";

            //Act
            var viewResult = controller.EditCategory(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Couldnt find a category with id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_DeleteCategory_GoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "2";
            var expectedCategory = new Category { CategoryId = 2, Name = "test name" };

            //Act
            var viewResult = controller.DeleteCategory(categoryId) as ViewResult;
            var actualCategory = controller.ViewBag.Category;


            //Assert
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId);
            Assert.AreEqual(expectedCategory.Name, actualCategory.Name);

            Assert.AreEqual("", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_DeleteCategory_BadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "123abc";

            //Act
            var viewResult = controller.DeleteCategory(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid category id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_DeleteCategory_InvalidInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));
            string categoryId = "-1";

            //Act
            var viewResult = controller.DeleteCategory(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Couldnt find a category with id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Create() {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryName = "test name";

            //Act
            var viewResult = controller.Create(categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was added to the database", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Create_NotAdmin()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = false;

            string categoryName = "test name";

            //Act
            var viewResult = controller.Create(categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Only administrators can create categories", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void Category_Edit_GoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryName = "test name";
            string categoryId = "2";

            //Act
            var viewResult = controller.Edit(categoryId, categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was updated", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Edit_NotAdmin()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = false;

            string categoryName = "test name";
            string categoryId = "2";

            //Act
            var viewResult = controller.Edit(categoryId, categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Only administrators can edit categories", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Edit_BadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryName = "test name";
            string categoryId = "2asb";

            //Act
            var viewResult = controller.Edit(categoryId, categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid category id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Edit_InvalidInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryName = "test name";
            string categoryId = "-1";

            //Act
            var viewResult = controller.Edit(categoryId, categoryName) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not update the category", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void Category_Delete_GoodInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryId = "2";

            //Act
            var viewResult = controller.Delete(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Category was deleted", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Delete_NotAdmin()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = false;

            string categoryId = "2";

            //Act
            var viewResult = controller.Delete(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Only administrators can delete categories", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Delete_BadInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryId = "2asb";

            //Act
            var viewResult = controller.Delete(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid category id: " + categoryId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void Category_Delete_InvalidInput()
        {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(controller);
            controller.Session["Admin"] = true;

            string categoryId = "-1";

            //Act
            var viewResult = controller.Delete(categoryId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not delete the category", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }







        /*
                [TestMethod]
        public void Index() {

            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryRepoStub()));

            //Act
            var viewResult = controller.EditImage(goodInput) as ViewResult;


            //Assert

        }
        */









    }
}

