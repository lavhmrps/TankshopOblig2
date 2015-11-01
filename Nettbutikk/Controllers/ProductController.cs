using Nettbutikk.Models;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController()
        {
        }

        // GET: Product
        public ActionResult Product(int ProductId,string ReturnUrl)
        {
            var product = Services.Categories.GetById<ProductView>(ProductId);
            ViewBag.Product = product;
            ViewBag.Product.Category = Services.Categories.GetById(product.ProductId);
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.LoggedIn = LoginStatus();

            return View();
        }

        public bool LoginStatus()
        {
            bool LoggedIn = false;

            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool)Session["LoggedIn"];
            }

            return LoggedIn;
        }
    }
}