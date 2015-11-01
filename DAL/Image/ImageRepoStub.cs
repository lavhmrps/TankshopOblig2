using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Image
{
    public class ImageRepoStub : IImageRepo
    {
        public bool AddImage(int productId, string imageUrl)
        {
            return productId != -1;
        }

        public bool AddOldImage(int productId, string imageUrl, int adminId)
        {
            return productId != -1;
        }

        public bool DeleteImage(int imageId)
        {
            return imageId != -1;
        }

        public List<Oblig1_Nettbutikk.Model.Image> GetAllImages()
        {
            var allImages = new List<Oblig1_Nettbutikk.Model.Image> {
                new Oblig1_Nettbutikk.Model.Image { ImageId = 1, ProductId = 1, ImageUrl = "test1"},
                new Oblig1_Nettbutikk.Model.Image { ImageId = 2, ProductId = 2, ImageUrl = "test2"},
                new Oblig1_Nettbutikk.Model.Image { ImageId = 3, ProductId = 3, ImageUrl = "test3"},
                new Oblig1_Nettbutikk.Model.Image { ImageId = 4, ProductId = 4, ImageUrl = "test4"}
            };

            return allImages;
        }


        public Oblig1_Nettbutikk.Model.Image GetImage(int imageId)
        {
            
            return imageId == -1 ? null : new Oblig1_Nettbutikk.Model.Image { ImageId = imageId, ProductId = 1, ImageUrl = "test"};
        }


        public bool UpdateImage(int imageId, int productId, string imageUrl)
        {

            return imageId != -1 && productId != -1; 
           
        }

    }
}
