using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Category
{
    public interface CategoryLogic
    {

        bool AddCategory(string Name);
        bool UpdateCategory(int CategoryId, string Name);
        bool DeleteCategory(int CategoryId);
        List<Oblig1_Nettbutikk.Model.Category> GetAllCategories();
        Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId);
        

    }
}
