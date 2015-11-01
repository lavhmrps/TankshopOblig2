namespace Nettbutikk.Model
{
    public class OrderlineModel
    {
        public int OrderlineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Count { get; set; }
    }
}
