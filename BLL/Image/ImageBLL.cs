using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace BLL.Image
{
    public class ImageBLL : IImageLogic
    {

        private DAL.Image.IImageRepo repo;

        public ImageBLL() {
            repo = new DAL.Image.ImageRepo();
        }

        public ImageBLL(DAL.Image.IImageRepo repo) {
            this.repo = repo;
        }

        public bool AddImage(int productId, string imageUrl)
        {
            return repo.AddImage(productId,imageUrl);
        }

        public bool DeleteImage(int imageId)
        {
            Oblig1_Nettbutikk.Model.Image img = repo.GetImage(imageId);

            if (img == null)
                return false;

            if (!repo.AddOldImage(img.ProductId, img.ImageUrl, 1))//Get admin id from session
                return false; 

            return repo.DeleteImage(imageId);
        }

        public List<Oblig1_Nettbutikk.Model.Image> GetAllImages()
        {
            return repo.GetAllImages();
        }

        public Oblig1_Nettbutikk.Model.Image GetImage(int imageId)
        {
            return repo.GetImage(imageId);
        }

        public bool UpdateImage(int imageId, int productId, string imageUrl)
        {

            Oblig1_Nettbutikk.Model.Image img = repo.GetImage(imageId);

            if (img == null)
                return false;

            if (!repo.AddOldImage(img.ProductId, img.ImageUrl, 1))//Get admin id from session
                return false;

            return repo.UpdateImage(imageId, productId, imageUrl);
        }
    }
}
