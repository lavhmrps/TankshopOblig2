using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers
{
    public class ImageController : BaseController
    {
        public ImageController()
            : base()
        {

        }

        public ImageController(params IService[] services)
            : base(services)
        {
        }

        // GET: Image
        public ActionResult Index()
        {
            ViewBag.Images = Services.Images.GetAllImages();

            return View("ListImage");
        }

        [HttpPost]
        public ActionResult Create(CreateImage image) {

            if (!Services.Images.AddImage(image.ProductId, image.ImageUrl))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not add the image to the database";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Image was added to the database";
            }

            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult Edit(EditImage image) {
            
            if (!Services.Images.UpdateImage(image.ImageId, image.ProductId, image.ImageUrl)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not update the image";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Image was updated";
            }
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult Delete(int? ImageId) {
            int imageId = -1;

            if(null == ImageId)
            {
                return new HttpNotFoundResult();
            }

            try
            {
                Services.Images.DeleteImage(imageId);

                ViewBag.Title = "Success";
                ViewBag.Message = "Image was deleted";
            }
            catch (Exception e)
            {
                Logger.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not delete the image";
                return View("~/Views/Shared/Result.cshtml");
            }
            
            return View("~/Views/Shared/Result.cshtml");   
        }


        public ActionResult CreateImage()
        {

            List<SelectListItem> productIDs = new List<SelectListItem>();

            foreach (Product p in Services.Products.GetAll())
            {
                string productId = Convert.ToString(p.Id);
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
                Logger.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Image img = Services.Images.GetImage(nImageId);

            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Couldnt find an image with id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }


            List<SelectListItem> productIDs = new List<SelectListItem>();

            foreach (Product p in Services.Products.GetAll())
            {
                string productId = Convert.ToString(p.Id);
                productIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            ViewBag.ProductIDs = productIDs;
            ViewBag.Image = img;

            return View();
        }


        public ActionResult DeleteImage(string imageId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + imageId);

            int nImageId;

            try
            {
                nImageId = Convert.ToInt32(imageId);
            }
            catch (Exception e)
            {
                Logger.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid image id: " + imageId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Image img = Services.Images.GetImage(nImageId);

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