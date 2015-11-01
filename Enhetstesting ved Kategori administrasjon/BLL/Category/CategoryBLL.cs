using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace BLL.Category
{
    public class CategoryBLL : CCategoryLogic
    {

        private DAL.Category.CCategoryRepo repo;

        public CategoryBLL() {
            repo = new DAL.Category.CategoryRepo();
        }

        public CategoryBLL(DAL.Category.CCategoryRepo repo) {
            this.repo = repo;
        }

        public bool AddCategory(int productId, string CategoryId)
        {
            return repo.AddCategory(productId,CategoryId);
        }

        public bool DeleteCategory(int CategoryId)
        {
            Oblig1_Nettbutikk.Model.Category category = repo.GetCategory(CategoryId);

            if (img == null)
                return false;

            if (!repo.AddOldCategory(category.ProductId, category.CategoryId, 1))//Get admin id from session
                return false; 

            return repo.DeleteCategory(CategoryId);
        }

        public List<Oblig1_Nettbutikk.Model.Category> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public Oblig1_Nettbutikk.Model.Category GetCategory(int CategoryId)
        {
            return repo.GetCategory(CategoryId);
        }

        public bool UpdateCategory(int CategoryId, int productId, string CategoryId)
        {

            Oblig1_Nettbutikk.Model.Category category = repo.GetCategory(CategoryId);

            if (img == null)
                return false;

            if (!repo.AddOldCategory(img.ProductId, img.CategoryId, 1))//Get admin id from session
                return false;

            return repo.UpdateCategory(categoryId, productId, CategoryId);
        }
    }
}
