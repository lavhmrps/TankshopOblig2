using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;


namespace DAL.Category
{
    public class CategoryRepo : CCategoryRepo
    {


        public Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId)
        {
            try {
                return new TankshopDbContext().Categories.FirstOrDefault(i => i.CategoryId == CategoryId);
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return null;
            }

        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {

            try {
                return new TankshopDbContext().Categories.ToList();
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return new List<Oblig1_Nettbutikk.Model.Category>();
            }
            
        }


        public bool AddCategory(int productId, string CategoryId)
        {

            try
            {
                var db = new TankshopDbContext();
                db.Categories.Add(new Oblig1_Nettbutikk.Model.Category() { ProductId = productId, CategoryId = CategoryId });
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
            
        }

        public bool DeleteCategory(int CategoryId)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Category categroy = (from i in db.Categories where i.CategoryId == CategoryId select i).FirstOrDefault();

            if (category == null)
            {
                return false;
            }

            try {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }

        public bool UpdateCategory(int CategoryId, int productId, string CategoryName)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Category category = (from i in db.Categories where i.CategoryId == CategoryId select i).FirstOrDefault();

            if (category == null)
            {
                return false;
            }

            category.ProductId = productId;
            category.CategoryId = categoryId;


            try {
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }


        //OldCategory
        public bool AddOldCategory(int productId, string CategoryId, int adminId)
        {

            var db = new TankshopDbContext();
            OldCategory oldCategory = new OldCategory();

            oldCategory.ProductId = productId;
            oldCategory.CategoryId = CategoryId;
            oldCategory.AdminId = adminId;
            oldCategory.Changed = DateTime.Now;

            db.OldCategories.Add(oldCategory);

            try {
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }


    }
}
