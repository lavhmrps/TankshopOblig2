using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TankshopDbContext context)
            : base(context)
        {

        }
    }
}
