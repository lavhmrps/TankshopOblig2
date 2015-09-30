using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Nettbutikk.Models;
using Nettbutikk.Models.Bindings;

namespace Nettbutikk.Controllers.Admin
{
    [RoutePrefix("Admin")]
    [Authorize(Roles = "Administrator,Manager,Owner")]
    [ModelBinder(typeof(Product))]
    public class ProductsAdminController : ProductsController
    {
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();

                db.Products.Add(product);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Category = await db.Categories.FindAsync(product.CategoryId);

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = await db.Products.FindAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = await db.Categories.FindAsync(product.CategoryId);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProduct product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Category = await db.Categories.FindAsync(product.CategoryId);

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = await db.Products.FindAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Product product = await db.Products.FindAsync(id);

            db.Products.Remove(product);

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}