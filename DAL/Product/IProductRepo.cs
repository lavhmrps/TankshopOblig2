using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.DAL
{
    public interface IProductRepo
    {

        Product GetProduct(int ProductId);
        ProductModel GetProductModel(int productId);
        List<ProductModel> GetProducts(List<int> productIdList);
        List<ProductModel> GetProductsByCategory(int categoryId);
        List<Product> GetAllProducts();

        bool AddProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);
        bool DeleteProduct(int ProductId);
        bool UpdateProduct(int ProductId, string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId);

        bool AddOldProduct(string Name, double Price, int Stock, string Description, string ImageUrl, int CategoryId, int AdminId);


    }
}
