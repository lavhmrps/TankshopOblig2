
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public class ProductRepo : IProductRepo
    {
        public List<ProductModel> GetProducts(List<int> productIdList)
        {
            var productList = new List<ProductModel>();
            try
            {
                using (var db = new TankshopDbContext())
                {

                    foreach (var productId in productIdList)
                    {
                        var product = db.Products.Find(productId);
                        if (product != null)
                        {
                            var productModel = new ProductModel()
                            {
                                ProductId = product.ProductId,
                                ProductName = product.Name,
                                Description = product.Description,
                                Price = product.Price,
                                Stock = product.Stock,
                                ImageUrl = product.ImageUrl,
                                CategoryId = product.CategoryId,
                                CategoryName = product.Category.Name
                            };

                            productList.Add(productModel);
                        }
                    }

                    return productList;
                }
            }
            catch (Exception)
            {
                return productList;
            }
        }
    }
}
