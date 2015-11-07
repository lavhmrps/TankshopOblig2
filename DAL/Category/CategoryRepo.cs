using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Logging;
using Nettbutikk.DAL;

namespace Nettbutikk.Model
{
    public class CategoryRepo : ICategoryRepo
    {


        //public Category GetCategory(int CategoryId)
        //{
        //    try
        //    {
        //        return new TankshopDbContext().Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        //    }
        //    catch (Exception e)
        //    {
        //        LogHandler.WriteToLog(e);
        //        return null;
        //    }

        //}

        public List<CategoryModel> GetAllCategories()
        {

            var db = new TankshopDbContext();

            var dbCategories = db.Categories.ToList();
            var categoryModels = new List<CategoryModel>();

            foreach (var c in dbCategories)
            {
                var categoryModel = new CategoryModel()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name
                    //Products = c.Products;
                };

                categoryModels.Add(categoryModel);

            }
            return categoryModels;
        }

        //public List<Category> GetAllCategories()
        //{

        //    try
        //    {
        //        return new TankshopDbContext().Categories.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        LogHandler.WriteToLog(e);
        //        return new List<Category>();
        //    }

        //}


        public bool AddCategory(string name)
        {

            try
            {
                var db = new TankshopDbContext();
                db.Categories.Add(new Category() { Name = name });
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

            Category category = (from c in db.Categories where c.CategoryId == CategoryId select c).FirstOrDefault();

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

            Category category = (from c in db.Categories where c.CategoryId == CategoryId select c).FirstOrDefault();

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

            Category c = new TankshopDbContext().Categories.Find(CategoryId);

            return c == null ? null : c.Name;

        }

        //public string GetCategoryName(int categoryId)
        //{
        //    using (var db = new TankshopDbContext())
        //    {
        //        return db.Categories.Find(categoryId).Name;
        //    }
        //}

        public List<CategoryModel> AllCategories()
        {
            using (var db = new TankshopDbContext())
            {
                var dbCategories = db.Categories.ToList();
                var categoryModels = new List<CategoryModel>();
                foreach (var c in dbCategories)
                {
                    var categoryModel = new CategoryModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.Name,
                        //Products = GetProductsByCategory(c.CategoryId)

                    };
                    categoryModels.Add(categoryModel);
                }
                return categoryModels;
            }
        }

        public CategoryModel GetCategory(int CategoryId)
        {
            using (var db = new TankshopDbContext())
            {
                var dbCategory = db.Categories.Find(CategoryId);
                var categoryModel = new CategoryModel();
                if(dbCategory != null)
                {
                    categoryModel.CategoryId = dbCategory.CategoryId;
                    categoryModel.CategoryName = dbCategory.Name;
                }

                return categoryModel;
            }
        }

        public int FirstCategoryWithProducts()
        {
            using (var db = new TankshopDbContext())
            {
                var FirstCategoryWithProducts = db.Categories.Where(c => c.Products.Count > 0).FirstOrDefault();
                return FirstCategoryWithProducts == null ? 0 : FirstCategoryWithProducts.CategoryId;
            }
        }
    }

}