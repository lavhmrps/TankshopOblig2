using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;
using Nettbutikk.DataAccess;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class ImageControllerTests
    {

        //GoodInput = input of correct type and value
        //BadInput = input of wrong type. For example "abc123" being sent instead of an int
        //Invalid = input of correct type, but wrong value. For example a product id of -1


        [TestMethod]
        public void Index()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var expectedResults = new List<Image> {
                new Image { ImageId = 1, ProductId = 1, ImageUrl = "test1"},
                new Image { ImageId = 2, ProductId = 2, ImageUrl = "test2"},
                new Image { ImageId = 3, ProductId = 3, ImageUrl = "test3"},
                new Image { ImageId = 4, ProductId = 4, ImageUrl = "test4"}
            };


            //Act
            var viewResult = controller.Index() as ViewResult;
            var actualResults = controller.ViewBag.Images;


            //Assert
            Assert.AreEqual(expectedResults.Count, actualResults.Count);

            for (int i = 0; i < actualResults.Count; i++)
            {
                Assert.AreEqual(expectedResults[i].ImageId, actualResults[i].ImageId);
                Assert.AreEqual(expectedResults[i].ProductId, actualResults[i].ProductId);
                Assert.AreEqual(expectedResults[i].ImageUrl, actualResults[i].ImageUrl);
            }


            Assert.AreEqual("ListImage", viewResult.ViewName);
        }

        [TestMethod]
        public void CreateImage()
        {

            //Arrange
            var controller = new ImageController(new IService[] { new ImageBLL(new ImageRepoStub()), new ProductService(new ProductRepository(new TankshopDbContext())) });

            var expectedImage = new Image { ImageId = 1, ProductId = 1, ImageUrl = "test" };
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
            var viewResult = controller.CreateImage() as ViewResult;
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
        public void EditImageGoodInput()
        {

            //Arrange
            var controller = new ImageController(new IService[] { new ImageBLL(new ImageRepoStub()), new ProductService(new ProductRepository(new TankshopDbContext())) });

            var expectedImage = new Image { ImageId = 1, ProductId = 1, ImageUrl = "test" };
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

            string goodInput = "1";

            //Act
            var viewResult = controller.EditImage(goodInput) as ViewResult;
            var actualImage = controller.ViewBag.Image;
            var actualProductIDs = controller.ViewBag.ProductIDs;

            //Assert
            Assert.AreEqual(expectedImage.ImageId, actualImage.ImageId);
            Assert.AreEqual(expectedImage.ImageId, actualImage.ImageId);
            Assert.AreEqual(expectedImage.ImageId, actualImage.ImageId);

            Assert.AreEqual(expectedProductIDs.Count, actualProductIDs.Count);
            for (int i = 0; i < actualProductIDs.Count; i++)
            {
                Assert.AreEqual(expectedProductIDs[i].Text, actualProductIDs[i].Text);
                Assert.AreEqual(expectedProductIDs[i].Value, actualProductIDs[i].Value);
            }

            Assert.AreEqual("", viewResult.ViewName);
        }


        [TestMethod]
        public void EditImageBadInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            string badInput = "bad input";

            //Act
            var viewResult = controller.EditImage(badInput) as ViewResult;


            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid image id: " + badInput, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void EditImageNoImageFound()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            string badImageId = "-1";

            //Act
            var viewResult = controller.EditImage(badImageId) as ViewResult;


            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Couldnt find an image with id: " + badImageId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void DeleteImageGoodInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            string imageId = "2";

            Image expectedResult = new Image { ImageId = 2, ProductId = 1, ImageUrl = "test" };

            //Act
            var viewResult = controller.DeleteImage(imageId) as ViewResult;
            var actualResult = controller.ViewBag.Image;

            //Assert
            Assert.AreEqual(expectedResult.ImageId, actualResult.ImageId);
            Assert.AreEqual(expectedResult.ProductId, actualResult.ProductId);
            Assert.AreEqual(expectedResult.ImageUrl, actualResult.ImageUrl);

            Assert.AreEqual("", viewResult.ViewName);
        }

        [TestMethod]
        public void DeleteImageBadInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            string imageId = "bad input";

            //Act
            var viewResult = controller.DeleteImage(imageId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid image id: " + imageId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteImageNoImageFound()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            string imageId = "-1";

            //Act
            var viewResult = controller.DeleteImage(imageId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could find an image with the id: " + imageId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void CreateGoodInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var image = new CreateImage {
                ProductId = 1,
                ImageUrl = "uri"
            };
            //Act
            var viewResult = controller.Create(image) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Image was added to the database", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void CreateBadInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var image = new CreateImage()
            {
                ProductId = -1,
                ImageUrl = "url"
            };
            //Act
            var viewResult = controller.Create(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid product id", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void CreateInvalidProductId()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var image = new CreateImage
            {
                ProductId = -1,
                ImageUrl = "url"
            };
            //Act
            var viewResult = controller.Create(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not add the image to the database", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditGoodInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));

            var image = new EditImage
            {
                ImageId = 1,
                ProductId = 1,
                ImageUrl = "url"
            };

            //Act
            var viewResult = controller.Edit(image) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Image was updated", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }


        [TestMethod]
        public void EditBadImageId()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));

            var image = new EditImage
            {
                ImageId = -1,
                ProductId = -1,
                ImageUrl = "url"
            };

            //Act
            var viewResult = controller.Edit(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid image id: " + image.ImageId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditBadProductId()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));

            var image = new EditImage
            {
                ImageId = 1,
                ProductId = -1,
                ImageUrl = "url"
            };

            //Act
            var viewResult = controller.Edit(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid product id: " + image.ProductId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditInvalidImageId()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var image = new EditImage
            {
                ProductId = 1,
                ImageId = -1,
                ImageUrl = "url"
            };
            //Act
            var viewResult = controller.Edit(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not update the image", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void EditInvalidProductId()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var image = new EditImage
            {
                ImageId = 1,
                ProductId = -1,
                ImageUrl = "url"
            };
            //Act
            var viewResult = controller.Edit(image) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not update the image", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);
        }


        [TestMethod]
        public void DeleteGoodInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var goodImageId = 1;

            //Act
            var viewResult = controller.Delete(goodImageId) as ViewResult;

            //Assert
            Assert.AreEqual("Success", controller.ViewBag.Title);
            Assert.AreEqual("Image was deleted", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteBadInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var badImageId = -1;

            //Act
            var viewResult = controller.Delete(badImageId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Invalid image id: " + badImageId, controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

        [TestMethod]
        public void DeleteInvalidInput()
        {

            //Arrange
            var controller = new ImageController(new ImageBLL(new ImageRepoStub()));
            var imageId = -1;

            //Act
            var viewResult = controller.Delete(imageId) as ViewResult;

            //Assert
            Assert.AreEqual("Error", controller.ViewBag.Title);
            Assert.AreEqual("Could not delete the image", controller.ViewBag.Message);
            Assert.AreEqual("~/Views/Shared/Result.cshtml", viewResult.ViewName);

        }

    }
}

