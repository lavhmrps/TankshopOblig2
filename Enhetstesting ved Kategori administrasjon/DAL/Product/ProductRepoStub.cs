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
        public List<CategoryModel> AllCategories()
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

        public string GetCategoryName(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProduct(int productId)
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
    }
}
