using System.Collections.Generic;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;

namespace Nettbutikk.BusinessLogic
{
    internal class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(CategoryRepository categoryRepository)
            : base(categoryRepository)
        {
        }

        public IEnumerable<Category> GetAll(ICollection<int> categoryIdList)
        {
            return Get(category => categoryIdList.Contains(category.CategoryId));
        }
    }
}