using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ITankshopDbContext context)
            : base(context)
        {

        }
    }
}
