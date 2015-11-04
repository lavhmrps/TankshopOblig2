using Nettbutikk.Model;
using Nettbutikk.Models;
using System.Net;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers
{
    [Authorize(Roles = "Administrator"), RoutePrefix("admin")]
    public class AdminProductsController : BaseController
    {
        public AdminProductsController() : base()
        {

        }

        public AdminProductsController(ServiceManager services) : base(services)
        {
        }
        #region Create

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(new CreateProduct
            {
                Categories = Services.Categories.GetAll<CategoryView>()
            });
        }

        // POST: Products/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(
            CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                Services.Products.Create(product);

                return RedirectToAction("Details", "Products", new { Id = product.Id });
            }

            if (null == product.Categories)
                product.Categories = Services.Categories.GetAll<CategoryView>();

            return View(product);
        }

        #endregion Create
        #region Edit

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpBadRequest();
            }

            EditProduct product = Services.Products.GetById<EditProduct>(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            product.Categories = Services.Categories.GetAll();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditProduct product)
        {
            if (ModelState.IsValid)
            {
                Services.Products.Update(product);

                return RedirectToAction("Index");
            }

            product.Categories = Services.Categories.GetAll();

            return View(product);
        }

        #endregion Edit
        #region Delete

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpBadRequest();
            }

            Product product = Services.Products.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [ActionName("Delete"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Services.Products.RemoveById(id))
            {
                return HttpBadRequest();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}