using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.DataAccess
{
    public interface IImageRepo
    {

        bool AddImage(int productId, string imageUrl);
        bool UpdateImage(int imageId, int productId, string imageUrl);
        bool DeleteImage(int imageId);
        List<Image> GetAllImages();
        Image GetImage(int imageId);


        //OldImage
        bool AddOldImage(int productId, string imageUrl, Admin admin);


    }
}
