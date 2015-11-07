using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Category
{
    public class CategoryRepoStub : ICategoryRepo
    {
        public bool AddCategory(string Name)
        {
            return Name != "invalid";
        }

        public bool AddOldCategory(string Name, int adminId)
        {
            return Name != "invalid";
        }

        public bool DeleteCategory(int CategoryId)
        {
            return CategoryId != -1;
        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {
            var allCategories = new List<Oblig1_Nettbutikk.Model.Category> {
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 1, Name = "test name 1"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 2, Name = "test name 2"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 3, Name = "test name 3"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 4, Name = "test name 4"}
            };

            return allCategories;
        }

        public List<CategoryModel> GetAllCategoryModels()
        {
            throw new NotImplementedException();
        }

        public Oblig1_Nettbutikk.Model.Category GetCategory(int categoryId)
        {
            
            return categoryId == -1 ? null : new Oblig1_Nettbutikk.Model.Category { CategoryId = categoryId, Name = "test name"};
        }

        public string GetCategoryName(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(int CategoryId, string Name)
        {

            return CategoryId != -1;
           
        }

    }
}
