using Microsoft.AspNet.Identity.Owin;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationRoleManager _AppRoleManager;
        
        /*
        * Base instance for all controllers in this project.
        * Makes adding and removing site-wide solutions such as
        * sessions and authentication much easier.
        */

        protected ApplicationRoleManager RoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        
        private bool IsCurrentUser(User user)
        {
            User.Identity.Equals(user);
        }

    }
}