using Nettbutikk.DataAccess;
using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    internal class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(CategoryRepository categoryRepository)
            : base(categoryRepository)
        {
        }

        public ICollection<Category> GetAll(ICollection<int> categoryIdList)
        {
            return Get(category => categoryIdList.Contains(category.CategoryId));
        }
    }
}
