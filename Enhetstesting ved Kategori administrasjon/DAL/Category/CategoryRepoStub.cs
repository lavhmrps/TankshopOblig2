using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Category
{
    public class CategoryRepoStub : CCategoryRepo
    {
        public bool AddCategory(int productId, string CategoryName)
        {
            return productId != -1;
        }

        public bool AddOldCategory(int productId, string CategoryNane, int adminId)
        {
            return productId != -1;
        }

        public bool DeleteCategory(int CategoryId)
        {
            return CategoryId != -1;
        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {
            var allCategories = new List<Oblig1_Nettbutikk.Model.Category> {
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 1, ProductId = 1, CategoryName = "test1"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 2, ProductId = 2, CategoryName = "test2"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 3, ProductId = 3, CategoryName = "test3"},
                new Oblig1_Nettbutikk.Model.Category { CategoryId = 4, ProductId = 4, CategoryName = "test4"}
            };

            return allCategories;
        }


        public Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId)
        {
            
            return CategoryId == -1 ? null : new Oblig1_Nettbutikk.Model.Category { CategoryId = categoryId, ProductId = 1, CategoryName = "test"};
        }


        public bool UpdateCategory(int CategoryId, int productId, string CategoryName)
        {

            return CategoryId != -1 && productId != -1; 
           
        }

    }
}
