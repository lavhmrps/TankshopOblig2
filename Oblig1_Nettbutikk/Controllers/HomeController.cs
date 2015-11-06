
using Newtonsoft.Json;
using Nettbutikk.BLL;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class HomeController : Controller
    {
        private IProductLogic _productBLL;

        public HomeController()
        {
            _productBLL = new ProductBLL();
        }

        public HomeController(IProductLogic stub)
        {
            _productBLL = stub;
        }


        public ActionResult Index()
        {
            var categories = _productBLL.AllCategories().Select(c => new CategoryView()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }
            ).ToList();

            var products = _productBLL.GetProductsByCategory(1).Select( p => new ProductView()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryName = p.CategoryName
            }).ToList();

            ViewBag.Categories = categories ?? new List<CategoryView>();
            ViewBag.Products = products ?? new List<ProductView>();
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = _productBLL.GetCategoryName(1);
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"] : "";
            return View();
        }

        public ActionResult Category(int CategoryId)
        {
            var categories = _productBLL.AllCategories().Select(c => new CategoryView()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }
            ).ToList();

            var products = _productBLL.GetProductsByCategory(CategoryId).Select(p => new ProductView()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName
            }).ToList(); 

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.LoggedIn = LoginStatus();
            ViewBag.CategoryName = _productBLL.GetCategoryName(CategoryId) ?? "Epler?";

            return View("Index");
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