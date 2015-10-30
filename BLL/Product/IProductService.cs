using Nettbutikk.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  A product mapped entityservice.
     */
    public interface IProductService :
        IEntityService<Product>, IMappedEntityService<Product>
    {
        IEnumerable<Product> GetAll(ICollection<int> productIdList);
        IEnumerable<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList);
        IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>(ICollection<int> productIdList);
        Product GetById(int productId);
        IEnumerable<Product> GetProductsByCategory(Category category);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        IEnumerable<TMappedType> GetMappedProductsByCategoryId<TMappedType>(int v);
        Task<TMappedEntity> GetByIdAsync<TMappedEntity>(int? id);
    }
}
