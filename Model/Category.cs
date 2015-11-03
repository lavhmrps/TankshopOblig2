using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
