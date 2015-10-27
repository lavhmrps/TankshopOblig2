using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Image
{
    public interface IImageRepo
    {

        void AddImage(int productId, string imageUrl);
        void UpdateImage(int imageId, int productId, string imageUrl);
        void DeleteImage(int imageId);
        List<Oblig1_Nettbutikk.Model.Image> GetAllImages();
        Oblig1_Nettbutikk.Model.Image GetImage(int imageId);


    }
}
