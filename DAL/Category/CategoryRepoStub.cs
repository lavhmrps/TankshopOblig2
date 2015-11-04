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
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 1, Name = "test1"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 2, Name = "test2"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 3, Name = "test3"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 4, Name = "test4"}
            };

            return allCategories;
        }


        public Oblig1_Nettbutikk.Model.Category GetCategory(int categoryId)
        {
            
            return categoryId == -1 ? null : new Oblig1_Nettbutikk.Model.Category { CategoryId = categoryId, Name = "test"};
        }


        public bool UpdateCategory(int CategoryId, string Name)
        {

            return CategoryId != -1;
           
        }

    }
}
