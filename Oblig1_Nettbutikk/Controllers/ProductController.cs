using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(int ProductId,string ReturnUrl)
        {
            var product = DB.GetProductById(ProductId);
            ViewBag.Product = product;
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
    }
}