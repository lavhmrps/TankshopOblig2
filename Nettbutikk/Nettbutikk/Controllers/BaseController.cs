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
        
        private bool IsCurrentUser(User user)
        {
            return User.Identity.Equals(user);
        }

        private UserManager _userManager;

        protected UserManager UserManager
        {
            get
            {
                return _userManager ?? (_userManager = Request.GetOwinContext().GetUserManager<UserManager>());
            }

        private SignInManager<User, Guid> _signInManager;

        protected SignInManager<User, Guid> SignInManager
        {
            get
            {
                return _signInManager ?? (_signInManager = Request.GetOwinContext().GetUserManager<SignInManager<User, Guid>>());
            }
        }

    }
}