using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.Model;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {

            ViewBag.Categories = Services.Categories.GetAll();

            return View("ListCategory");
        }


        public ActionResult CreateCategory() {

            List<SelectListItem> CategoryIds = new List<SelectListItem>();

            foreach (Product product in Services.Products.GetAll())
            {
                CategoryIds.Add(new SelectListItem { Text = product.Category.Name, Value = Convert.ToString(product.CategoryId) });
            }

            ViewBag.CategoryIds = CategoryIds;

            return View();
        }

        [HttpPost]
        public ActionResult create(string CategoryIds, string CategoryId)
        {
            //Sjekke om product id eksisterer?

            int nCategoryId = Convert.ToInt32(CategoryIds);

            Category category = new Category() { CategoryId = nCategoryId };

            Services.Categories.Create(category);

            try {
                Services.Categories.SaveChanges();
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
        public ActionResult edit(CategoryView c)
        {
            Category category = Services.Categories.GetById(c.CategoryId);

            if (category == null) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an Category with id " + c.CategoryId + " in the database";
            }
            else
            {
                category.Name = c.Name;

                Services.Categories.Update(category);

                ViewBag.Title = "Success";
                ViewBag.Message = "Category was updated";
            }

            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult delete(int CategoryId)
        {
            if (!Services.Categories.RemoveById(CategoryId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find an category with id " + CategoryId + " in the database";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Category was deleted";
            }

            return View("~/Views/Shared/Result.cshtml");   
        }

        public ActionResult EditCategory(string CategoryId)
        {
            Category category = db.Categories.Find(Convert.ToInt32(categoryId));

            if (category == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }


        public ActionResult DeleteCategory(string categoryId)
        {
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