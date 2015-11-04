using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Model;
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
        private IProductLogic _productBLL;

        public ProductController()
        {
            _productBLL = new ProductBLL();
        }

        public ProductController(IProductLogic stub)
        {
            _productBLL = stub;
        }


        public ActionResult Index() {

            var db = new TankshopDbContext();

            List<Product> allProducts = db.Products.ToList();

            ViewBag.Products = allProducts;

            return View("ListProduct");
        }

        public ActionResult CreateProduct()
        {

            var db = new TankshopDbContext();

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            List<Category> allCategories = db.Categories.ToList();


            foreach (Category c in allCategories)
            {
                string categoryId = Convert.ToString(c.CategoryId);
                categoryIds.Add(new SelectListItem { Text = c.Name, Value = categoryId});
            }

            ViewBag.CategoryIds = categoryIds;

            return View();
        }

        public ActionResult EditProduct(string ProductId)
        {
            var db = new TankshopDbContext();

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            List<Category> allCategories = db.Categories.ToList();

            foreach (Category c in allCategories)
            {
                string categoryId = Convert.ToString(c.CategoryId);
                categoryIds.Add(new SelectListItem { Text = c.Name, Value = categoryId });
            }

            ViewBag.CategoryIds = categoryIds;

            Product p = db.Products.Find(Convert.ToInt32(ProductId));

            ViewBag.Product = p;

            return View();
        }

        public ActionResult DeleteProduct(string ProductId)
        {
            var db = new TankshopDbContext();

            Product p = db.Products.Find(Convert.ToInt32(ProductId));

            ViewBag.Product = p;

            return View();
        }

        [HttpPost]
        public ActionResult Create(string Name, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
        {

            var db = new TankshopDbContext();

            Product p = new Product() { Name = Name, Price = Convert.ToDouble(Price), Stock = Convert.ToInt32(Stock),
                Description = Description, ImageUrl = ImageUrl, CategoryId = Convert.ToInt32(CategoryIds)};

            db.Products.Add(p);
            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Product was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(string ProductId, string Name, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
        {

            var db = new TankshopDbContext();

            Product p = db.Products.Find(Convert.ToInt32(ProductId));

            p.Name = Name;
            p.Price = Convert.ToDouble(Price);
            p.Stock = Convert.ToInt32(Stock);
            p.Description = Description;
            p.ImageUrl = ImageUrl;
            p.CategoryId = Convert.ToInt32(CategoryIds);

            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Product was successfully updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Delete(string ProductId)
        {

            var db = new TankshopDbContext();

            Product p = db.Products.Find(Convert.ToInt32(ProductId));

            db.Products.Remove(p);
            db.SaveChanges();

            ViewBag.Title = "Success";
            ViewBag.Message = "Product was deleted from the database";
            return View("~/Views/Shared/Result.cshtml");
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