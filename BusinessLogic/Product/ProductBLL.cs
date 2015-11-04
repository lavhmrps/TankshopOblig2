using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace Nettbutikk.BusinessLogic
{
    public class ProductBLL : IProductLogic
    {
        private IProductRepo _repo;

        public ProductBLL()
        {
            _repo = new ProductRepo();
        }

        public ProductBLL(IProductRepo stub)
        {
            _repo = stub;
        }

        public List<CategoryModel> AllCategories()
        {
            return _repo.AllCategories();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public string GetCategoryName(int categoryId)
        {
            return _repo.GetCategoryName(categoryId);
        }

        public ProductModel GetProduct(int productId)
        {
            return _repo.GetProduct(productId);
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            return _repo.GetProducts(productIdList);
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            return _repo.GetProductsByCategory(categoryId);
        }
    }
}
