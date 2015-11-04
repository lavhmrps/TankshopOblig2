using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.BLL
{
    public interface IProductLogic
    {
        List<ProductModel> GetProducts(List<int> productIdList);
        ProductModel GetProduct(int productId);
        List<ProductModel> GetProductsByCategory(int categoryId);
        string GetCategoryName(int categoryId);
        List<CategoryModel> AllCategories();
        List<ProductModel> GetAllProducts();
    }
}
