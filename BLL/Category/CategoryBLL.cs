using Nettbutikk.DataAccess;
using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public class CategoryBLL : CCategoryLogic
    {

        private CCategoryRepo repo;

        public CategoryBLL() {
            repo = new CategoryRepo();
        }

        public CategoryBLL(CCategoryRepo repo) {
            this.repo = repo;
        }

        public bool AddCategory(int productId, string CategoryId)
        {
            return repo.AddCategory(productId,CategoryId);
        }

        public bool DeleteCategory(int CategoryId)
        {
            Category category = repo.GetCategory(CategoryId);
            
            return repo.DeleteCategory(CategoryId);
        }

        public List<Category> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public Category GetCategory(int CategoryId)
        {
            return repo.GetCategory(CategoryId);
        }

        public bool UpdateCategory(int categoryId, string categoryName)
        {
            Category category = repo.GetCategory(categoryId);
            
            return repo.UpdateCategory(categoryId, categoryName);
        }
    }
}
