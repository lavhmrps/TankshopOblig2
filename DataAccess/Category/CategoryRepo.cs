using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nettbutikk.DataAccess
{
    public class CategoryRepo : ICategoryRepo
    {
        public Category GetCategory(int CategoryId)
        {
            try {
                return new TankshopDbContext().Categories.FirstOrDefault(i => i.CategoryId == CategoryId);
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return null;
            }

        }

        public List<Category> GetAllCategories()
        {

            try {
                return new TankshopDbContext().Categories.ToList();
            }
            catch (Exception e) {
                //LogHandler.WriteToLog(e);
                return new List<Category>();
            }
            
        }


        public bool AddCategory(string CategoryId)
        {

            try
            {
                var db = new TankshopDbContext();
                db.Categories.Add(new Category() {CategoryId = Convert.ToInt32(CategoryId) });
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
            
        }

        public bool DeleteCategory(int CategoryId)
        {

            var db = new TankshopDbContext();

            Category category = (from i in db.Categories where i.CategoryId == CategoryId select i).FirstOrDefault();

            if (category == null)
            {
                return false;
            }

            try {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool UpdateCategory(int CategoryId, string CategoryName)
        {

            var db = new TankshopDbContext();

            Category category = (from i in db.Categories where i.CategoryId == CategoryId select i).FirstOrDefault();

            if (category == null)
            {
                return false;
            }
            
            category.Name = CategoryName;


            try {
                db.SaveChanges();
                return true;
            }
            catch (Exception e) { }//LogHandler.WriteToLog(e); }

            return false;
        }
    }
}
