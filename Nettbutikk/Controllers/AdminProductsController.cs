using AutoMapper;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System.Net;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Create(
            CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                Product p = await Services.Products.CreateAsync(product);

                return RedirectToAction("Details", "Products", new { Id = p.Id });
            }

            if (null == product.Categories)
                product.Categories = Services.Categories.GetAll<CategoryView>();

            return View(product);
        }

        #endregion Create
        #region Edit

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditProduct product = await Services.Products.GetByIdAsync<EditProduct>(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            product.Categories = await Services.Categories.GetAllAsync();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProduct product)
        {
            if (ModelState.IsValid)
            {
                await Services.Products.UpdateAsync(product);

                return RedirectToAction("Index");
            }

            product.Categories = await Services.Categories.GetAllAsync();

            return View(product);
        }

        #endregion Edit
        #region Delete

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = await Services.Products.GetByIdAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [ActionName("Delete"), HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await Services.Products.GetByIdAsync(id);

            await Services.Products.RemoveAsync(product);

            return RedirectToAction("Index");
        }

        #endregion
    }
}