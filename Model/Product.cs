using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }

    }

}
