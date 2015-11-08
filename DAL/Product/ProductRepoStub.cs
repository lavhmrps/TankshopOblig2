using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace DAL.Product
{
    public class ProductRepoStub : IProductRepo
    {
        public bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId)
        {
            throw new NotImplementedException();
        }

        public bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> AllCategories()
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            return new List<ProductModel> {
                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new ProductModel { ProductId = 1, ProductName = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
            };

        }

        public string GetCategoryName(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProducts(string searchstr)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
