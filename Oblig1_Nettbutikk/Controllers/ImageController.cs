using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {

            ViewBag.Images = new TankshopDbContext().Images.ToList();

            return View("ListImage");
        }


        public ActionResult CreateImage() {

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

        [HttpPost]
        public ActionResult create(string ProductIDs, string ImageUrl) {

            System.Diagnostics.Debug.WriteLine("HTTP POST create");
            System.Diagnostics.Debug.WriteLine("Got ProductId: " + ProductIDs);
            System.Diagnostics.Debug.WriteLine("Got url: " + ImageUrl);

            var db = new TankshopDbContext();

            //Sjekke om product id eksisterer?

            int nProductId = Convert.ToInt32(ProductIDs);
       
            Image img = new Image() { ProductId = nProductId, ImageUrl = ImageUrl};

            db.Images.Add(img);

            try {
                db.SaveChanges();
            } catch (Exception e) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with id " + ProductIDs;
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Image was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult edit(string ImageId, string ProductId, string ImageUrl) {

            System.Diagnostics.Debug.WriteLine("HTTP POST edit");
            System.Diagnostics.Debug.WriteLine("Got ImageId: " + ImageId);
            System.Diagnostics.Debug.WriteLine("Got ProductId: " + ProductId);
            System.Diagnostics.Debug.WriteLine("Got url: " + ImageUrl);

            var db = new TankshopDbContext();

            int imgId = Convert.ToInt32(ImageId);
            Image img = (from i in db.Images where i.ImageId == imgId select i).FirstOrDefault();

            if (img == null) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an image with id " + ImageId + " in the database";
                return View("~/Views/Shared/Result.cshtml");
            }

            img.ProductId = Convert.ToInt32(ProductId);
            img.ImageUrl = ImageUrl;

            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Image was updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult delete(string ImageId) {

            System.Diagnostics.Debug.WriteLine("HTTP POST delete");
            System.Diagnostics.Debug.WriteLine("Got ImageId: " + ImageId);

            var db = new TankshopDbContext();

            int imgId = Convert.ToInt32(ImageId);
            Image img = (from i in db.Images where i.ImageId == imgId select i).FirstOrDefault();

            if (img == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an image with id " + ImageId + " in the database";
                return View("~/Views/Shared/Result.cshtml");
            }

            db.Images.Remove(img);
            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Image was deleted";
            return View("~/Views/Shared/Result.cshtml");   
        }

        public ActionResult EditImage(string imageId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + imageId);

            var db = new TankshopDbContext();

            Image img = db.Images.Find(Convert.ToInt32(imageId));

            if (img == null)
            {
                System.Diagnostics.Debug.WriteLine("No such image in db");
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Image = img;

            return View();
        }


        public ActionResult DeleteImage(string imageId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + imageId);

            var db = new TankshopDbContext();

            Image img = db.Images.Find(Convert.ToInt32(imageId));

            if (img == null)
            {
                System.Diagnostics.Debug.WriteLine("No such image in db");
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Image = img;

            return View();
        }

    }
}