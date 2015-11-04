using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController()
            : base()
        {
        }

        public CategoryController(ServiceManager services)
            : base(services)
        {
        }
        
        // GET: Image
        public ActionResult Index()
        {
            ViewBag.Categories = Services.Categories.GetAll();

            return View("ListCategory");
        }

        [HttpPost]
        public ActionResult Create(CreateCategory category)
        {

            if (!Services.Categories.Create(category))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not add the category to the database";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Category was added to the database";
            }
            return View("~/Views/Shared/Result.cshtml");
        }
        
        [HttpPost]
        public ActionResult Edit(EditCategory model)
        {
            if (!Services.Categories.Update(model))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not update the category";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Category was updated";
            }
            return View("~/Views/Shared/Result.cshtml");
        }

        public ActionResult Delete(int categoryId)
        {
            if (!Services.Categories.RemoveById(categoryId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not delete the category";
            }
            else
            {
                ViewBag.Title = "Success";
                ViewBag.Message = "Category was deleted";
            }

            return View("~/Views/Shared/Result.cshtml");
        }
        
        public ActionResult CreateCategory()
        {
            return View();
        }
        
        public ActionResult EditCategory(int categoryId)
        {
            Category category = Services.Categories.GetById(categoryId);

            if (category == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Couldnt find a category with id: " + categoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }
        
        public ActionResult DeleteCategory(int categoryId)
        {
            Category category = Services.Categories.GetById(categoryId);

            if (category == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could find a category with the id: " + categoryId;
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Category = category;

            return View();
        }
    }
}