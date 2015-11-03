using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.DataAccess
{
    public interface CCategoryRepo
    {

        bool AddCategory(int categoryId, string CategoryName);
        bool UpdateCategory(int categoryId, string categoryName);
        bool DeleteCategory(int categoryId);
        List<Category> GetAllCategories();
        Category GetCategory(int categoryId);
    }
}
