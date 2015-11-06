using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public interface IProductRepo
    {
        List<ProductModel> GetProducts(List<int> productIdList);
        List<ProductModel> GetProducts(string searchstr);
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProductsByCategory(int categoryId);
        string GetCategoryName(int categoryId);
        List<CategoryModel> AllCategories();
        List<ProductModel> GetAllProducts();
    }
}
