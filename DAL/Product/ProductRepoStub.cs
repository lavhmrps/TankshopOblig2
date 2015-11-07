using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
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

        public List<Product> GetAllProducts()
        {
            return new List<Product> {
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1},
                new Product { ProductId = 1, Name = "tank", Price = 150, Stock = 5, Description = "blows things up", CategoryId = 1}
            };
        }

        public Product GetProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductModel(int productId)
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
