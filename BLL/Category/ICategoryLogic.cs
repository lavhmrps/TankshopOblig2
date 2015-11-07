using System.Collections.Generic;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace Nettbutikk.BLL
{
    public interface ICategoryLogic
    {
        bool AddCategory(string Name);
        bool DeleteCategory(int CategoryId);
        //List<Category> GetAllCategories();
        //List<CategoryModel> GetAllCategoryModels();
        List<CategoryModel> GetAllCategories();
        //Category GetCategory(int CategoryId);
        CategoryModel GetCategory(int CategoryId);
        string GetCategoryName(int CategoryId);
        bool UpdateCategory(int CategoryId, string Name);
        int FirstCategoryWithProducts();
    }
}