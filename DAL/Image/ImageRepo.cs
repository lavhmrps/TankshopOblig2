using System;
using System.Collections.Generic;
using System.Linq;
using Nettbutikk.Model;
using Nettbutikk.Model.RemovedEntities;

namespace Nettbutikk.DataAccess
{
    public class ImageRepo : IImageRepo
    {


        public Image GetImage(int imageId)
        {
            try {
                return new TankshopDbContext().Images.FirstOrDefault(i => i.ImageId == imageId);
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return null;
            }

        }

        public List<Image> GetAllImages()
        {

            try {
                return new TankshopDbContext().Images.ToList();
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return new List<Image>();
            }
            
        }


        public bool AddImage(int productId, string imageUrl)
        {

            try
            {
                var db = new TankshopDbContext();
                db.Images.Add(new Image() { ProductId = productId, ImageUrl = imageUrl });
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
            
        }

        public bool DeleteImage(int imageId)
        {

            var db = new TankshopDbContext();

            Image img = (from i in db.Images where i.ImageId == imageId select i).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            try {
                db.Images.Remove(img);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }

        public bool UpdateImage(int imageId, int productId, string imageUrl)
        {

            var db = new TankshopDbContext();

            Image img = (from i in db.Images where i.ImageId == imageId select i).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.ProductId = productId;
            img.ImageUrl = imageUrl;


            try {
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }


        //OldImage
        public bool AddOldImage(int productId, string imageUrl, Admin admin)
        {
            var db = new TankshopDbContext();
            OldImage oldImage = new OldImage();

            oldImage.ProductId = productId;
            oldImage.ImageUrl = imageUrl;
            oldImage.Changer = admin;
            oldImage.Changed = DateTime.Now;
            
            try {
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }


    }
}
