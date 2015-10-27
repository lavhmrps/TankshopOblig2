using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Image
{
    public class ImageRepo : IImageRepo
    {


        public Oblig1_Nettbutikk.Model.Image GetImage(int imageId)
        {
            return new TankshopDbContext().Images.Find(imageId);
        }

        public List<Oblig1_Nettbutikk.Model.Image> GetAllImages()
        {
            return new TankshopDbContext().Images.ToList();
        }


        public void AddImage(int productId, string imageUrl)
        {

            var db = new TankshopDbContext();
            db.Images.Add(new Oblig1_Nettbutikk.Model.Image() { ProductId = productId, ImageUrl = imageUrl });
            db.SaveChanges();

        }

        public void DeleteImage(int imageId)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Image img = (from i in db.Images where i.ImageId == imageId select i).FirstOrDefault();

            if (img == null)
            {
                //throw?
                //Image does not exist
                return;
            }

            db.Images.Remove(img);
            db.SaveChanges();

        }

        public void UpdateImage(int imageId, int productId, string imageUrl)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Image img = (from i in db.Images where i.ImageId == imageId select i).FirstOrDefault();

            if (img == null)
            {
                //throw?
                return;
            }

            img.ProductId = productId;
            img.ImageUrl = imageUrl;

            db.SaveChanges();
        }

    }
}
