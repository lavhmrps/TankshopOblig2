using System.Collections.Generic;

namespace Nettbutikk.Model
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
