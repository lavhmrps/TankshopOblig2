using Nettbutikk.BusinessLogic;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        private IProductLogic _productBLL;

        public ProductController()
        {
            _productBLL = new ProductBLL();
        }

        public ProductController(IProductLogic stub)
        {
            _productBLL = stub;
        }

        // GET: Product
        public ActionResult Product(int ProductId,string ReturnUrl)
        {
            var productmodel = _productBLL.GetProduct(ProductId);
            var categoryname = _productBLL.GetCategoryName(productmodel.CategoryId);
            var productview = new ProductView()
            {
                ProductId = productmodel.ProductId,
                ProductName = productmodel.ProductName,
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