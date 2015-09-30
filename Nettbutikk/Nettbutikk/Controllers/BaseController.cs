using Microsoft.AspNet.Identity.Owin;
using Nettbutikk.DAL;
using Nettbutikk.Infrastructure;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    /**
    * <summary>
    * Base instance for all controllers in this project.
    * Makes managing site-wide solutions such as
    * sessions and authentication much easier.
    * </summary>
    */
    [RequireHttps]
    public class BaseController : Controller
    {
        private NettbutikkContext _db;
        
        /**
         * <summary>
         * A reference to the local database context.
         * </summary>
         */
        protected NettbutikkContext db
        {
            get { return _db ?? (_db = new NettbutikkContext()); }
        }

        public BaseController()
        {
            _db = new NettbutikkContext();
        }

        private RoleManager _roleManager;

        protected RoleManager RoleManager
        {
            get
            {
                return _roleManager ?? (_roleManager = Request.GetOwinContext().GetUserManager<RoleManager>());
            }
        }

        private UserManager _userManager;

        protected UserManager UserManager
        {
            get
            {
                return _userManager ?? (_userManager = Request.GetOwinContext().GetUserManager<UserManager>());
            }
        }

        private SignInManager<User, Guid> _signInManager;

        protected SignInManager<User, Guid> SignInManager
        {
            get
            {
                return _signInManager ?? (_signInManager = Request.GetOwinContext().GetUserManager<SignInManager<User, Guid>>());
            }
        }

        /**
         * Summary:
         *   A utility helper-method used to redirect to a local URI, or the index if it is not a local url.
         */
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}