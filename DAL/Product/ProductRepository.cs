using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(ITankshopDbContext context)
            : base(context)
        {

        }
    }
}
