using Oblig1_Nettbutikk.Models;
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
            var productmodel = DB.GetProductById(ProductId);
            var categoryname = DB.GetCategoryName(productmodel.CategoryId);
            var productview = new ProductView()
            {
                ProductId = productmodel.ProductId,
                ProductName = productmodel.Name,
                Description = productmodel.Description,
                Price = productmodel.Price,
                Stock = productmodel.Stock,
                ImageUrl = productmodel.ImageUrl,
                CategoryName = categoryname
            };
            

            ViewBag.Product = productview;
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