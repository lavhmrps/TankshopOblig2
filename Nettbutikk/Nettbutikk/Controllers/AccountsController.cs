using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountsController : BaseController
    {

        [Authorize(Roles = "Administrator")]
        [Route("all")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        [Authorize(Roles = "Administrator")]
        [Route("details/{id:guid}")]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = await db.Users.FindAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [Route("details")]
        public async Task<ActionResult> Details()
        {
            //TODO: Implement getting current User and Guid
            return await Details(Guid.NewGuid());
        }

        [Route("register")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,PasswordHash,PasswordSalt")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Accounts/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = await db.Users.FindAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,PasswordHash,PasswordSalt")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
