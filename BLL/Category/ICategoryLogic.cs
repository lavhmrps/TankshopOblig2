using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public interface ICategoryLogic
    {
        bool AddCategory(string Name);
        bool DeleteCategory(int CategoryId);
        List<Category> GetAllCategories();
        List<CategoryModel> GetAllCategoryModels();
        Category GetCategory(int CategoryId);
        string GetCategoryName(int CategoryId);
        bool UpdateCategory(int CategoryId, string Name);
    }
}