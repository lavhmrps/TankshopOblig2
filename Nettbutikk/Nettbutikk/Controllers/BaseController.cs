using Microsoft.AspNet.Identity.Owin;
using Nettbutikk.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationRoleManager _AppRoleManager = null;

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        /*
        * Base instance for all controllers in this project.
        * Makes adding and removing site-wide solutions such as
        * sessions and authentication much easier.
        */
    }
}