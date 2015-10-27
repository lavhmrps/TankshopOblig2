using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Image
{
    public interface IImageLogic
    {

        void AddImage(int productId, string imageUrl);
        void UpdateImage(int imageId, int productId, string imageUrl);
        void DeleteImage(int imageId);
        List<Oblig1_Nettbutikk.Model.Image> GetAllImages();
        Oblig1_Nettbutikk.Model.Image GetImage(int imageId);

    }
}
