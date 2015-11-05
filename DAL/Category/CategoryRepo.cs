using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;
using Logging;


namespace DAL.Category
{
    public class CategoryRepo : ICategoryRepo
    {


        public Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId)
        {
            try
            {
                return new TankshopDbContext().Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                return null;
            }

        }

        public List<CategoryModel> GetAllCategoryModels()
        {

            var db = new TankshopDbContext();

            var dbCategories = db.Categories.ToList();
            var categoryModels = new List<CategoryModel>();

            foreach (var c in dbCategories)
            {
                var categoryModel = new CategoryModel()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name,
                    //Products = c.Products;
                };

                categoryModels.Add(categoryModel);

            }


            return categoryModels;
        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {

            try
            {
                return new TankshopDbContext().Categories.ToList();
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
                return new List<Oblig1_Nettbutikk.Model.Category>();
            }

        }


        public bool AddCategory(string name)
        {

            try
            {
                var db = new TankshopDbContext();
                db.Categories.Add(new Oblig1_Nettbutikk.Model.Category() { Name = name });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
            }

            return false;

        }

        public bool DeleteCategory(int CategoryId)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Category category = (from c in db.Categories where c.CategoryId == CategoryId select c).FirstOrDefault();

            if (category == null)
                return false;


            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
            }

            return false;
        }

        public bool UpdateCategory(int CategoryId, string Name)
        {

            var db = new TankshopDbContext();

            Oblig1_Nettbutikk.Model.Category category = (from c in db.Categories where c.CategoryId == CategoryId select c).FirstOrDefault();

            if (category == null)
                return false;


            category.CategoryId = CategoryId;
            category.Name = Name;


            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
            }

            return false;
        }


        public bool AddOldCategory(string Name, int adminId)
        {

            var db = new TankshopDbContext();
            OldCategory oldCategory = new OldCategory();

            oldCategory.Name = Name;
            oldCategory.AdminId = adminId;
            oldCategory.Changed = DateTime.Now;

            db.OldCategories.Add(oldCategory);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteToLog(e);
            }

            return false;
        }

        public string GetCategoryName(int CategoryId)
        {

            Oblig1_Nettbutikk.Model.Category c = new TankshopDbContext().Categories.Find(CategoryId);

            return c == null ? null : c.Name;

        }

    }

}
