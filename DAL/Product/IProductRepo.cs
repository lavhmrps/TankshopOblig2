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
        List<CategoryModel> AllCategories();
        string GetCategoryName(int categoryId);
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProducts(List<int> productIdList);
        List<ProductModel> GetProductsByCategory(int categoryId);
    }
}
