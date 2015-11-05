using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.DAL;

namespace Oblig1_Nettbutikk.BLL
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

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public ProductModel GetProductModel(int productId)
        {
            return _repo.GetProductModel(productId);
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            return _repo.GetProducts(productIdList);
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            return _repo.GetProductsByCategory(categoryId);
        }

        public Product GetProduct(int ProductId)
        {
            return _repo.GetProduct(ProductId);
        }

        public bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            return _repo.AddProduct(Name,Price,Stock,Description,ImageUrl,CategoryId);
        }

        public bool DeleteProduct(int ProductId)
        {
            Product product = _repo.GetProduct(ProductId);

            if (product == null)
                return false;

            if (!_repo.AddOldProduct(product.Name, product.Price, product.Stock,
                product.Description, product.ImageUrl, product.CategoryId, 1))//Get admin id from session
                return false;

            return _repo.DeleteProduct(ProductId);
        }

        public bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            Product product = _repo.GetProduct(ProductId);

            if (product == null)
                return false;

            if (!_repo.AddOldProduct(product.Name, product.Price, product.Stock,
                product.Description, product.ImageUrl, product.CategoryId, 1))//Get admin id from session
                return false;

            return _repo.UpdateProduct(ProductId, Name, Price, Stock, Description, ImageUrl, CategoryId);
        }

    }
}
