using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Product
{ 

    public interface IProductLogic
    {
        List<ProductModel> GetProducts(List<int> productIdList);
        List<ProductModel> GetProducts(string searchstr);
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProductsByCategory(int categoryId);
        //string GetCategoryName(int categoryId);
        //List<CategoryModel> AllCategories();
        List<ProductModel> GetAllProducts();

        bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);
        bool DeleteProduct(int ProductId);
        bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);
        bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId);
    }
}
