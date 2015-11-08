using Logging;
using Nettbutikk.Viewmodels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Product;
using BLL.Category;

namespace Nettbutikk.Controllers
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


        // GET: Product
        public ActionResult Product(int ProductId, string ReturnUrl)
        {
            var product = _productBLL.GetProduct(ProductId);

            var imageViews = new List<ImageView>();
            foreach (var image in product.Images)
            {
                var imageView = new ImageView()
                {
                    ImageId = image.ImageId,
                    ProductId = image.ProductId,
                    ImageUrl = image.ImageUrl
                };
                imageViews.Add(imageView);
            }
            var productView = new ProductView()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                Images = imageViews
            };


            ViewBag.Product = productView;
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.LoggedIn = LoginStatus();
            return View();
        }

        public ActionResult Index()
        {
            var productModels = _productBLL.GetAllProducts();

            var products = new List<ProductView>();
            foreach (var product in productModels)
            {
                var imageViews = new List<ImageView>();
                foreach (var image in product.Images)
                {
                    var imageView = new ImageView()
                    {
                        ImageId = image.ImageId,
                        ProductId = image.ProductId,
                        ImageUrl = image.ImageUrl
                    };
                    imageViews.Add(imageView);
                }
                var productView = new ProductView()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock,
                    CategoryName = product.CategoryName,
                    Images = imageViews
                };
                products.Add(productView);
            }

            ViewBag.Products = products;

            return View("ListProduct");
        }

        public ActionResult CreateProduct()
        {

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            var allCategories = _categoryBLL.GetAllCategoryModels();

            foreach (var c in allCategories)
            {
                string categoryId = Convert.ToString(c.CategoryId);
                categoryIds.Add(new SelectListItem { Text = c.CategoryName, Value = categoryId });
            }

            ViewBag.CategoryIds = categoryIds;

            return View();
        }

        public ActionResult EditProduct(string ProductId)
        {

            List<SelectListItem> categoryIds = new List<SelectListItem>();
            var allCategories = _categoryBLL.GetAllCategoryModels();

            foreach (var c in allCategories)
            {
                string categoryId = Convert.ToString(c.CategoryId);
                categoryIds.Add(new SelectListItem { Text = c.CategoryName, Value = categoryId });
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

            var product = _productBLL.GetProduct(nProductId);

            if (product == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with the id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }


            var imageViews = new List<ImageView>();
            foreach (var image in product.Images)
            {
                var imageView = new ImageView()
                {
                    ImageId = image.ImageId,
                    ProductId = image.ProductId,
                    ImageUrl = image.ImageUrl
                };
                imageViews.Add(imageView);
            }
            var productView = new ProductView()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                Images = imageViews
            };

            ViewBag.Product = productView;

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

            var product = _productBLL.GetProduct(nProductId);

            if (product == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Could not find a product with the id: " + ProductId;
                return View("~/Views/Shared/Result.cshtml");
            }


            var imageViews = new List<ImageView>();
            foreach (var image in product.Images)
            {
                var imageView = new ImageView()
                {
                    ImageId = image.ImageId,
                    ProductId = image.ProductId,
                    ImageUrl = image.ImageUrl
                };
                imageViews.Add(imageView);
            }
            var productView = new ProductView()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = product.CategoryName,
                Images = imageViews
            };
            ViewBag.Product = productView;

            return View();
        }

        [HttpPost]
        public ActionResult Create(string ProductName, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
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

            //Check for invalid int/doubles
            if (!_productBLL.AddProduct(ProductName, dPrice, nStock, Description, ImageUrl, nCategoryId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Product was not added to the database";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Product was added to the database";
            return View("~/Views/Shared/Result.cshtml");
        }

        [HttpPost]
        public ActionResult Edit(string ProductId, string ProductName, string Price, string Stock, string Description, string ImageUrl, string CategoryIds)
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

            if (!_productBLL.UpdateProduct(nProductId, ProductName, dPrice, nStock, Description, ImageUrl, nCategoryId))
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

            if (!_productBLL.DeleteProduct(nProductId))
            {
                ViewBag.Title = "Error";
                ViewBag.Message = "Product could not be deleted from the database";
                return View("~/Views/Shared/Result.cshtml");
            }


            ViewBag.Title = "Success";
            ViewBag.Message = "Product was deleted from the database";
            return View("~/Views/Shared/Result.cshtml");
        }

        public string Products(string searchstr)
        {
            var result = _productBLL.GetProducts(searchstr);
            var jsonResult = JsonConvert.SerializeObject(result);
            return jsonResult;
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