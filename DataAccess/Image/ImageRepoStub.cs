using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.DataAccess
{
    public class ImageRepoStub : IImageRepo
    {
        public bool AddImage(int productId, string imageUrl)
        {
            return productId != -1;
        }

        public bool AddOldImage(int productId, string imageUrl, Admin changer)
        {
            return productId != -1;
        }

        public bool DeleteImage(int imageId)
        {
            return imageId != -1;
        }

        public List<Image> GetAllImages()
        {
            var allImages = new List<Image> {
                new Image { ImageId = 1, ProductId = 1, ImageUrl = "test1"},
                new Image { ImageId = 2, ProductId = 2, ImageUrl = "test2"},
                new Image { ImageId = 3, ProductId = 3, ImageUrl = "test3"},
                new Image { ImageId = 4, ProductId = 4, ImageUrl = "test4"}
            };

            return allImages;
        }


        public Image GetImage(int imageId)
        {
            
            return imageId == -1 ? null : new Image { ImageId = imageId, ProductId = 1, ImageUrl = "test"};
        }


        public bool UpdateImage(int imageId, int productId, string imageUrl)
        {

            return imageId != -1 && productId != -1; 
           
        }

    }
}
