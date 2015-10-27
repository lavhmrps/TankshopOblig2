using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Model;
using BLL.Image;

namespace Oblig1_Nettbutikk.Controllers
{
    public class ImageController : Controller
    {

        private ImageBLL imageBLL;

        public ImageController() {
            imageBLL = new ImageBLL();
        }

        // GET: Image
        public ActionResult Index()
        {

            ViewBag.Images = imageBLL.GetAllImages();

            return View("ListImage");
        }

        [HttpPost]
        public ActionResult create(string ProductIDs, string ImageUrl) {

            System.Diagnostics.Debug.WriteLine("HTTP POST create");
            System.Diagnostics.Debug.WriteLine("Got ProductId: " + ProductIDs);
            System.Diagnostics.Debug.WriteLine("Got url: " + ImageUrl);

            try {

                imageBLL.AddImage(Convert.ToInt32(ProductIDs), ImageUrl);

            } catch (Exception) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not add the image to the database";
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Title = "Success";
            ViewBag.Message = "Image was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult edit(string ImageId, string ProductIDs, string ImageUrl) {

            System.Diagnostics.Debug.WriteLine("HTTP POST edit");
            System.Diagnostics.Debug.WriteLine("Got ImageId: " + ImageId);
            System.Diagnostics.Debug.WriteLine("Got ProductId: " + ProductIDs);
            System.Diagnostics.Debug.WriteLine("Got url: " + ImageUrl);

            try {

                imageBLL.UpdateImage(Convert.ToInt32(ImageId), Convert.ToInt32(ProductIDs),ImageUrl);

            }catch (Exception) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not update the image";
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Title = "Success";
            ViewBag.Message = "Image was updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult delete(string ImageId) {

            System.Diagnostics.Debug.WriteLine("HTTP POST delete");
            System.Diagnostics.Debug.WriteLine("Got ImageId: " + ImageId);

            try {

                imageBLL.DeleteImage(Convert.ToInt32(ImageId));

            }catch (Exception) {
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


            //Bruke ProductRepo for å hente ut alle produkter

            List<SelectListItem> productIDs = new List<SelectListItem>();
            var db = new TankshopDbContext();

            foreach (Product p in db.Products)
            {
                string productId = Convert.ToString(p.ProductId);
                productIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            ViewBag.ProductIDs = productIDs;

            return View();
        }



        public ActionResult EditImage(string imageId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + imageId);

            Image img = null;

            try {

                img = imageBLL.GetImage(Convert.ToInt32(imageId));

            }catch (Exception) {}


            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could find the specified image";
                return View("~/Views/Shared/Result.cshtml");
            }


            List<SelectListItem> productIDs = new List<SelectListItem>();
            var db = new TankshopDbContext();

            foreach (Product p in db.Products)
            {
                string productId = Convert.ToString(p.ProductId);
                productIDs.Add(new SelectListItem { Text = productId, Value = productId });
            }

            ViewBag.ProductIDs = productIDs;
            ViewBag.Image = img;

            return View();
        }


        public ActionResult DeleteImage(string imageId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + imageId);

            Image img = null;

            try
            {

                img = imageBLL.GetImage(Convert.ToInt32(imageId));

            }
            catch (Exception) { }


            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could find the specified image";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Image = img;

            return View();
        }

    }
}