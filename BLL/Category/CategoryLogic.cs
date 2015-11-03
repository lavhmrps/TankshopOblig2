using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public interface CCategoryLogic
    {

        bool AddCategory(int productId, string categoryName);
        bool UpdateCategory(int CategoryId, string categoryName);
        bool DeleteCategory(int CategoryId);
        List<Category> GetAllCategories();
        Category GetCategory(int CategoryId);

    }
}
