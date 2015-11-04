using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  A product mapped entityservice.
     */
    public interface IProductService :
        IEntityService<Product>, IMappedEntityService<Product>
    {
        ICollection<Product> GetAll(ICollection<int> productIdList);
        ICollection<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList);
        Product GetById(int productId);
        ICollection<Product> GetProductsByCategory(Category category);
        ICollection<Product> GetProductsByCategoryId(int categoryId);
        ICollection<TMappedType> GetProductsByCategoryId<TMappedType>(int v);
    }
}
