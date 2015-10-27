using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Image
{
    public class ImageBLL : IImageLogic
    {

        private DAL.Image.ImageRepo repo;

        public ImageBLL() {
            repo = new DAL.Image.ImageRepo();
        }

        public void AddImage(int productId, string imageUrl)
        {
            repo.AddImage(productId,imageUrl);
        }

        public void DeleteImage(int imageId)
        {
            repo.DeleteImage(imageId);
        }

        public List<Oblig1_Nettbutikk.Model.Image> GetAllImages()
        {
            return repo.GetAllImages();
        }

        public Oblig1_Nettbutikk.Model.Image GetImage(int imageId)
        {
            return repo.GetImage(imageId);
        }

        public void UpdateImage(int imageId, int productId, string imageUrl)
        {
            repo.UpdateImage(imageId, productId, imageUrl);
        }
    }
}
