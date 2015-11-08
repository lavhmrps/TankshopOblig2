using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using DAL.Product;
using DAL.Category;

namespace BLL.Product
{
    public class ProductBLL : IProductLogic
    {
        private IProductRepo _productRepo;
        private ICategoryRepo _categoryRepo;

        public ProductBLL()
        {
            _productRepo = new ProductRepo();
            _categoryRepo = new CategoryRepo();
        }

        public ProductBLL(IProductRepo stub)
        {
            _productRepo = stub;
            _categoryRepo = new CategoryRepoStub();
        }

        public List<CategoryModel> AllCategories()
        {
            return _categoryRepo.GetAllCategoryModels();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public string GetCategoryName(int categoryId)
        {
            return _categoryRepo.GetCategoryName(categoryId);
        }

        public ProductModel GetProduct(int productId)
        {
            return _productRepo.GetProduct(productId);
        }

        public List<ProductModel> GetProducts(string searchstr)
        {
            return _productRepo.GetProducts(searchstr);
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            return _productRepo.GetProducts(productIdList);
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            return _productRepo.GetProductsByCategory(categoryId);
        }

        public bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            return _productRepo.AddProduct(Name, Price, Stock, Description, ImageUrl, CategoryId);
        }

        public bool DeleteProduct(int ProductId)
        {
            return _productRepo.DeleteProduct(ProductId);
        }

        public bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            return _productRepo.UpdateProduct(ProductId, Name, Price, Stock, Description, ImageUrl, CategoryId);
        }

        public bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId)
        {
            return _productRepo.AddOldProduct(Name, Price, Stock, Description, ImageUrl, CategoryId,AdminId);
        }
    }
}
