using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Model;
using BLL.Image;
using Oblig1_Nettbutikk.BLL;
using Logging;

namespace Oblig1_Nettbutikk.Controllers
{
    public class ImageController : Controller
    {

        private IImageLogic imageBLL;
        private IProductLogic productBLL;

        public ImageController() {
            
            imageBLL = new ImageBLL();
            productBLL = new ProductBLL();
        
        }

        public ImageController(IImageLogic imageBLL, IProductLogic productBLL = null) {

            this.imageBLL = imageBLL;
            this.productBLL = productBLL;

        }

        public ActionResult Index()
        {

            List<Image> allImages = imageBLL.GetAllImages();

            ViewBag.Images = allImages;

            return View("ListImage");
        }

        [HttpPost]
        public ActionResult Create(string ProductIDs, string ImageUrl) {

            if (Session["Admin"] != null && (bool)Session["Admin"] == false) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Only administrators can create images";
                return View("~/Views/Shared/Result.cshtml");
            }

            int productId;

            try
            {
                productId = Convert.ToInt32(ProductIDs);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid product id";
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!imageBLL.AddImage(productId, ImageUrl)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not add the image to the database";
                return View("~/Views/Shared/Result.cshtml");
            }

         
            ViewBag.Title = "Success";
            ViewBag.Message = "Image was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult Edit(string ImageId, string ProductIDs, string ImageUrl) {

            if (Session["Admin"] != null && (bool)Session["Admin"] == false)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Only administrators can edit images";
                return View("~/Views/Shared/Result.cshtml");
            }

            int imageId;
            int productId;

            try
            {
                imageId = Convert.ToInt32(ImageId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + ImageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            try {
                productId = Convert.ToInt32(ProductIDs);
            }
            catch (Exception e) {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid product id: " + ProductIDs;
                return View("~/Views/Shared/Result.cshtml");
            }


            if (!imageBLL.UpdateImage(imageId, productId, ImageUrl)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not update the image";
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Title = "Success";
            ViewBag.Message = "Image was updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult Delete(string ImageId) {

            

            if (Session["Admin"] != null && (bool)Session["Admin"] == false)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Only administrators can delete images";
                return View("~/Views/Shared/Result.cshtml");
            }

            int imageId;

            try
            {
                imageId = Convert.ToInt32(ImageId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + ImageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!imageBLL.DeleteImage(imageId)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not delete the image";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Image was deleted";
            return View("~/Views/Shared/Result.cshtml");   
        }


        public ActionResult CreateImage()
        {

            List<SelectListItem> productIDs = new List<SelectListItem>();
            List<Product> allProducts = productBLL.GetAllProducts();

            foreach (Product p in allProducts)
            {
                string productId = Convert.ToString(p.ProductId);
                productIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            ViewBag.ProductIDs = productIDs;

            return View();
        }



        public ActionResult EditImage(string imageId) {

            int nImageId;

            try {
                nImageId = Convert.ToInt32(imageId);
            }
            catch (Exception e) {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Image img = imageBLL.GetImage(nImageId);

            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Couldnt find an image with id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }


            List<SelectListItem> productIDs = new List<SelectListItem>();
            List<Product> allProducts = productBLL.GetAllProducts();

            foreach (Product p in allProducts)
            {
                string productId = Convert.ToString(p.ProductId);
                productIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            ViewBag.ProductIDs = productIDs;
            ViewBag.Image = img;

            return View();
        }


        public ActionResult DeleteImage(string imageId) {

            int nImageId;

            try
            {
                nImageId = Convert.ToInt32(imageId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Image img = imageBLL.GetImage(nImageId);

            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could find an image with the id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Image = img;

            return View();
        }

    }
}