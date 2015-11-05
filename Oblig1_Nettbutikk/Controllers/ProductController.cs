using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Category;
using Logging;

namespace Oblig1_Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        private IProductLogic _productBLL;
        private ICategoryLogic _categoryBLL;

        public ProductController()
        {
            _productBLL = new ProductBLL();
            _categoryBLL = new CategoryBLL();
        }

        public ProductController(IProductLogic productStub, ICategoryLogic categoryStub)
        {
            _productBLL = productStub;
            _categoryBLL = categoryStub;
        }


        public ActionResult Index() {

            ViewBag.Products = _productBLL.GetAllProducts();

            return View("ListProduct");
        }

        public ActionResult CreateProduct()
        {

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            List<Category> allCategories = _categoryBLL.GetAllCategories();

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

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            List<Category> allCategories = _categoryBLL.GetAllCategories();

            foreach (Category c in allCategories)
            {
                string categoryId = Convert.ToString(c.CategoryId);
                categoryIds.Add(new SelectListItem { Text = c.Name, Value = categoryId });
            }

            ViewBag.CategoryIds = categoryIds;


            int nProductId;

            try
            {
                nProductId = Convert.ToInt32(ProductId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid prodct id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Product p = _productBLL.GetProduct(nProductId);

            if (p == null) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with the id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Product = p;

            return View();
        }

        public ActionResult DeleteProduct(string ProductId)
        {

            int nProductId;

            try
            {
                nProductId = Convert.ToInt32(ProductId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid prodct id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }

            Product p = _productBLL.GetProduct(nProductId);

            if (p == null) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }

            ViewBag.Product = p;

            return View();
        }

        [HttpPost]
        public ActionResult Create(string Name, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
        {


            double dPrice;

            try
            {
                dPrice = Convert.ToDouble(Price);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid price: " + Price;
                return View("~/Views/Shared/Result.cshtml");
            }


            int nStock;

            try
            {
                nStock= Convert.ToInt32(Stock);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid stock: " + Stock;
                return View("~/Views/Shared/Result.cshtml");
            }

            int nCategoryId;

            try
            {
                nCategoryId = Convert.ToInt32(CategoryIds);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid category id: " + CategoryIds; 
                return View("~/Views/Shared/Result.cshtml");
            }

            //Check for invalid int/doubles
            if (!_productBLL.AddProduct(Name,dPrice, nStock, Description, ImageUrl, nCategoryId)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Product was not added to the database";
                return View("~/Views/Shared/Result.cshtml");
            }
            

            ViewBag.Title = "Success";
            ViewBag.Message = "Product was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(string ProductId, string Name, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
        {

            int nProductId;

            try
            {
                nProductId = Convert.ToInt32(ProductId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid product id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }


            double dPrice;

            try
            {
                dPrice = Convert.ToDouble(Price);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid price: " + Price;
                return View("~/Views/Shared/Result.cshtml");
            }


            int nStock;

            try
            {
                nStock = Convert.ToInt32(Stock);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid stock: " + Stock;
                return View("~/Views/Shared/Result.cshtml");
            }

            int nCategoryId;

            try
            {
                nCategoryId = Convert.ToInt32(CategoryIds);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid category id: " + CategoryIds;
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!_productBLL.UpdateProduct(nProductId, Name, dPrice, nStock, Description, ImageUrl, nCategoryId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Product was not updated";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Product was successfully updated";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Delete(string ProductId)
        {

            int nProductId;

            try
            {
                nProductId = Convert.ToInt32(ProductId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                ViewBag.Title = "Error";
                ViewBag.Message = "Invalid product id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }

            if (!_productBLL.DeleteProduct(nProductId)) {
                ViewBag.Title = "Error";
                ViewBag.Message = "Product could not be deleted from the database";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Product was deleted from the database";
            return View("~/Views/Shared/Result.cshtml");
        }


        // GET: Product
        public ActionResult Product(int ProductId,string ReturnUrl)
        {
            
            var productmodel = _productBLL.GetProduct(ProductId);
            var categoryname = _categoryBLL.GetCategoryName(productmodel.CategoryId);

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