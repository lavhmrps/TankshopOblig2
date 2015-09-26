using Nettbutikk.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class BaseDbController : BaseController
    {
        protected NettbutikkContext db = new NettbutikkContext();
        /*
        * Base instance for all controllers in this project.
        * Makes adding and removing site-wide solutions such as
        * sessions and authentication much easier.
        */
    }
}