using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            ViewBag.Categories = new TankshopDbContext().Categories.ToList();

            return View("ListCategory");
        }


        public ActionResult CreateCategory() {

            List<SelectListItem> CategoryIds = new List<SelectListItem>();

            var db = new TankshopDbContext();

            foreach (Product p in db.Products)
            {
                string CategoryId = Convert.ToString(p.CategoryId);
                CategoryIds.Add(new SelectListItem { Text = CategoryId, Value = CategoryId });
            }

            ViewBag.CategoryIds = CategoryIds;

            return View();
        }

        [HttpPost]
        public ActionResult create(string CategoryIds, string CategoryId)
        {

            System.Diagnostics.Debug.WriteLine("HTTP POST create");
            System.Diagnostics.Debug.WriteLine("Got CategoryId: " + CategoryIds);
            System.Diagnostics.Debug.WriteLine("Got url: " + CategoryId);

            var db = new TankshopDbContext();

            //Sjekke om product id eksisterer?

            int nCategoryId = Convert.ToInt32(CategoryIds);

            Category category = new Category() { CategoryId = nCategoryId, CategoryId = CategoryId };

            db.Categories.Add(category);

            try {
                db.SaveChanges();
            } catch (Exception e) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with id " + CategoryIds;
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Category was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult edit(string CategoryName, string CategoryId, string CategoryId)
        {

            System.Diagnostics.Debug.WriteLine("HTTP POST edit");
            System.Diagnostics.Debug.WriteLine("Got CategoryName: " + CategoryName);
            System.Diagnostics.Debug.WriteLine("Got CategoryId: " + CategoryId);
            System.Diagnostics.Debug.WriteLine("Got CategoryId: " + CategoryId);

            var db = new TankshopDbContext();

            int CategoryId = Convert.ToInt32(CategoryId);
            Category category = (from i in db.Cateogries where i.CateogoryId == categoryId select i).FirstOrDefault();

            if (category == null) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an Category with id " + CategoryId + " in the database";
                return View("~/Views/Shared/Result.cshtml");
            }

            category.CategoryId = Convert.ToInt32(CategoryId);
            category.CategoryId = CategoryId;

            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Category was updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult delete(string CategoryId) {

            System.Diagnostics.Debug.WriteLine("HTTP POST delete");
            System.Diagnostics.Debug.WriteLine("Got CategoryId: " + CategoryId);

            var db = new TankshopDbContext();

            int categoryId = Convert.ToInt32(CategoryId);
            Cateogory category = (from i in db.Categories where i.CategoryId == categoryId select i).FirstOrDefault();

            if (category == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an category with id " + CategoryId + " in the database";
                return View("~/Views/Shared/Result.cshtml");
            }

            db.Category.Remove(category);
            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Category was deleted";
            return View("~/Views/Shared/Result.cshtml");   
        }

        public ActionResult EditCategory(string CategoryId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + categoryId);

            var db = new TankshopDbContext();

            Category category = db.Categories.Find(Convert.ToInt32(categoryId));

            if (category == null)
            {
                System.Diagnostics.Debug.WriteLine("No such category in db");
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }


        public ActionResult DeleteCategory(string categoryId) {

            System.Diagnostics.Debug.WriteLine("Got value: " + categoryId);

            var db = new TankshopDbContext();

            Category category = db.Categories.Find(Convert.ToInt32(categoryId));

            if (category == null)
            {
                System.Diagnostics.Debug.WriteLine("No such category in db");
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }

    }
}