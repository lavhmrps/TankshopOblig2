using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public interface IImageLogic : IService
    {

        bool AddImage(int productId, string imageUrl);
        bool UpdateImage(int imageId, int productId, string imageUrl);
        bool DeleteImage(int imageId);
        IList<Image> GetAllImages();
        Image GetImage(int imageId);

    }
}
