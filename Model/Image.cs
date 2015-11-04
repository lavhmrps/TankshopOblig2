using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }

}
