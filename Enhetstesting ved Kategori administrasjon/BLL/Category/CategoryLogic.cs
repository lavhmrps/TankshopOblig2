using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Category
{
    public interface CCategoryLogic
    {

        bool AddCategory(int productId, string CategoryId);
        bool UpdateCategory(int CategoryId, int productId, string CategoryId);
        bool DeleteCategory(int CategoryId);
        List<Oblig1_Nettbutikk.Model.Category> GetAllCategories();
        Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId);

    }
}
