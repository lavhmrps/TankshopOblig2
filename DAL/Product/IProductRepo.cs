using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Product
{
    public interface IProductRepo
    {
        List<ProductModel> GetAllProducts();
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProducts(List<int> productIdList);
        List<ProductModel> GetProducts(string searchstr);
        List<ProductModel> GetProductsByCategory(int categoryId);

        bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);
        bool DeleteProduct(int ProductId);
        bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);
        bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId);

        //ProductModel GetProductModel(int productId);
        //List<Product> GetAllProducts();


        //string GetCategoryName(int categoryId);
        //List<CategoryModel> AllCategories();
    }
}
