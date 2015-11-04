namespace Nettbutikk.Models
{
    public class CreateImage
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }

    public class EditImage
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}