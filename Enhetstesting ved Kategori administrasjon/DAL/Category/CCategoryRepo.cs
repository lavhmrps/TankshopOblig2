using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace DAL.Category
{
    public interface CCategoryRepo
    {

        bool AddCategory(int productId, string CategoryName);
        bool UpdateCategory(int CategoryId, int productId, string CategoryUrl);
        bool DeleteCategory(int CategoryId);
        List<Oblig1_Nettbutikk.Model.Category> GetAllCategorys();
        Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId);


        //OldCategory
        bool AddOldCategory(int productId, string CategoryName, int adminId);


    }
}
