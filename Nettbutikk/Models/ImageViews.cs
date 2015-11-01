namespace Nettbutikk.Models
{
    public class CreateImage
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }

    public class EditImage
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}