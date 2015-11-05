using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace BLL.Category
{
    public interface ICategoryLogic
    {

        bool AddCategory(string Name);
        bool UpdateCategory(int CategoryId, string Name);
        bool DeleteCategory(int CategoryId);
        List<Oblig1_Nettbutikk.Model.Category> GetAllCategories();
        Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId);
        List<CategoryModel> GetAllCategoryModels();
        string GetCategoryName(int CategoryId);

    }
}
