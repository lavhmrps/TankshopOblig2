
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public class ProductRepo : IProductRepo
    {
        public List<CategoryModel> AllCategories()
        {
            using (var db = new TankshopDbContext())
            {
                var dbCategories = db.Categories.ToList();
                var categoryModels = new List<CategoryModel>();
                foreach (var c in dbCategories)
                {
                    var categoryModel = new CategoryModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.Name,
                        Products = GetProductsByCategory(c.CategoryId)

                    };
                    categoryModels.Add(categoryModel);
                }
                return categoryModels;
            }
        }

        public string GetCategoryName(int categoryId)
        {
            using (var db = new TankshopDbContext())
            {
                return db.Categories.Find(categoryId).Name;
            }
        }

        public ProductModel GetProduct(int ProductId)
        {
            using (var db = new TankshopDbContext())
            {
                var product = db.Products.Find(ProductId);
                var productModel = new ProductModel()
                {
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Stock = product.Stock
                };
                return productModel;
            }
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            var productList = new List<ProductModel>();
            try
            {
                using (var db = new TankshopDbContext())
                {

                    foreach (var productId in productIdList)
                    {
                        var product = db.Products.Find(productId);
                        if (product != null)
                        {
                            var productModel = new ProductModel()
                            {
                                ProductId = product.ProductId,
                                ProductName = product.Name,
                                Description = product.Description,
                                Price = product.Price,
                                Stock = product.Stock,
                                ImageUrl = product.ImageUrl,
                                CategoryId = product.CategoryId,
                                CategoryName = product.Category.Name
                            };

                            productList.Add(productModel);
                        }
                    }

                    return productList;
                }
            }
            catch (Exception)
            {
                return productList;
            }
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            using(var db = new TankshopDbContext())
            {
                var dbProducts = db.Products.Where(p => p.CategoryId == categoryId).ToList();
                var productModels = new List<ProductModel>();
                foreach(var product in dbProducts)
                {
                    productModels.Add(new ProductModel()
                    {
                        CategoryId = product.CategoryId,
                        CategoryName = product.Category.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        Stock = product.Stock
                    });
                }
                return productModels;
                
            }
        }
    }
}
