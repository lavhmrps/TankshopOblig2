using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.DAL
{
    public interface ICategoryRepo
    {
        bool AddCategory(string name);
        bool AddOldCategory(string Name, int adminId);
        bool DeleteCategory(int CategoryId);
        List<Nettbutikk.Model.Category> GetAllCategories();
        List<CategoryModel> GetAllCategoryModels();
        Nettbutikk.Model.Category GetCategory(int CategoryId);
        string GetCategoryName(int CategoryId);
        bool UpdateCategory(int CategoryId, string Name);
    }
}