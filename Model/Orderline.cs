using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Orderline
    {
        [Key]
        public int OrderlineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Count { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
