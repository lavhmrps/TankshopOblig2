using Nettbutikk.BusinessLogic;
using System.Net;
using System.Web.Mvc;

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

        public BaseController(params IService[] services)
        {
            Services = new ServiceManager(services);
        }

        #endregion Constructors

        #region Helpers

        protected ActionResult HttpBadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        protected ActionResult RedirectToLocal(string returnUrl,
            RedirectToRouteResult defaultUrl = null)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return defaultUrl ?? RedirectToAction("Index", "Home");
        }

        protected bool LoginStatus()
        {
            bool LoggedIn = false;

            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool)Session["LoggedIn"];
            }

            return LoggedIn;
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