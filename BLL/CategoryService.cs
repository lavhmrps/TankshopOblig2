namespace Nettbutikk.BusinessLogic
{
    internal class CategoryService : ICategoryService
    {
        private CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}