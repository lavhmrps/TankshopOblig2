using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(ServiceManager services) : base(services)
        {
        }

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
        public ActionResult Create(CreateCategory c)
        {
            //Sjekke om product id eksisterer?

            int nCategoryId = Convert.ToInt32(c);

            Category category = new Category() { CategoryId = c.CategoryId, Name = c.Name };

            Services.Categories.Create(category);

            try {
                Services.Categories.SaveChanges();
            } catch (Exception e) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with id " + c.CategoryId;
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Category was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        [HttpPost]
        public ActionResult Edit(CategoryView c)
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

        public ActionResult Delete(int CategoryId)
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

        public ActionResult EditCategory(int CategoryId)
        {
            Category category = Services.Categories.GetById(CategoryId);

            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = category;

            return View();
        }


        public ActionResult DeleteCategory(int categoryId)
        {
            Category category = Services.Categories.GetById(categoryId);

            if (category == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }

    }
}