using Nettbutikk.Models;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ServiceManager services)
            : base(services)
        {
        }

        // GET: Product
        public ActionResult Product(int ProductId,string ReturnUrl)
        {
            var product = Services.Products.GetById(ProductId);

            if(null == product)
            {
                return new HttpNotFoundResult();
            }

            ViewBag.Product = product;
            ViewBag.Product.Category = Services.Categories.GetById(product.CategoryId);
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.LoggedIn = LoginStatus();

            return View();
        }
    }
}