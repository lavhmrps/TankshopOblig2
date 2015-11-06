using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace Nettbutikk.BLL
{
    public class ProductBLL : IProductLogic
    {
        private IProductRepo _repo;
        private ICategoryRepo _categoryrepo;

        public ProductBLL()
        {
            _repo = new ProductRepo();
            _categoryrepo = new CategoryRepo();
        }

        public ProductBLL(IProductRepo stub)
        {
            _repo = stub;
            _categoryrepo = new CategoryRepoStub();
        }

        public List<CategoryModel> AllCategories()
        {
            return _categoryrepo.GetAllCategories();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public string GetCategoryName(int categoryId)
        {
            return _categoryrepo.GetCategoryName(categoryId);
        }

        public ProductModel GetProduct(int productId)
        {
            return _repo.GetProduct(productId);
        }

        public List<ProductModel> GetProducts(string searchstr)
        {
            return _repo.GetProducts(searchstr);
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            return _repo.GetProducts(productIdList);
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            return _repo.GetProductsByCategory(categoryId);
        }

        public bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            return _repo.AddProduct(Name, Price, Stock, Description, ImageUrl, CategoryId);
        }

        public bool DeleteProduct(int ProductId)
        {
            return _repo.DeleteProduct(ProductId);
        }

        public bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            return _repo.UpdateProduct(ProductId, Name, Price, Stock, Description, ImageUrl, CategoryId);
        }

        public bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId)
        {
            return _repo.AddOldProduct(Name, Price, Stock, Description, ImageUrl, CategoryId,AdminId);
        }
    }
}
