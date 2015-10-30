using System.Web.Mvc;
using Nettbutikk.Infrastructure;

namespace Nettbutikk.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Properties and members

        // Used for XSRF protection when adding external logins
        protected const string XsrfKey = "{{Nettbutikk.XSRF.Token}}";

        protected ServiceManager Services { get; private set; }

        protected CookieHandler CookieHandler { get; private set; }

        #endregion Properties and members
        #region Constructors

        public BaseController()
        {
            Services = new ServiceManager();
            CookieHandler = new CookieHandler();
        }

        public BaseController(ServiceManager services)
        {
            Services = services;
        }

        #endregion
        #region Helpers
        
        protected ActionResult RedirectToLocal(string returnUrl,
            RedirectToRouteResult defaultUrl = null)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return defaultUrl ?? RedirectToAction("Index", "Home");
        }
        
        #endregion
        #region IDisposable Support

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Services.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion IDisposable Support
    }
}