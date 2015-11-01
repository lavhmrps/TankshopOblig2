using AutoMapper;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    public class ProductService : EntityService<Product>, IProductService
    {
        public ProductService(EntityRepository<Product> repository)
            : base(repository)
        {
        }

        public IEnumerable<Product> GetAll(ICollection<int> productIdList)
        {
            return Get(p => productIdList.Contains(p.ProductId));
        }

        public IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>(ICollection<int> productIdList)
        {
            return GetMapped<TMappedEntity>(p => productIdList.Contains(p.ProductId));
        }

        public Product GetById(int productId)
        {
            return Repository.GetById(productId);
        }

        public IEnumerable<TMappedType> GetMappedProductsByCategoryId<TMappedType>(int categoryId)
        {
            return Mapper.Map<IEnumerable<TMappedType>>(GetProductsByCategoryId(categoryId));
        }

        public IEnumerable<TMappedType> GetMappedProductsByCategory<TMappedType>(Category category)
        {
            return Mapper.Map<IEnumerable<TMappedType>>(GetProductsByCategoryId(category.CategoryId));
        }

        public IEnumerable<Product> GetProductsByCategory(Category category)
        {
            return GetProductsByCategoryId(category.CategoryId);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return Repository.Get(product => product.CategoryId == categoryId);
        }

        public IEnumerable<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            return GetAllMapped<TMappedEntity>(productIdList);
        }

        public async Task<TMappedEntity> GetByIdAsync<TMappedEntity>(int? id)
        {
            return Mapper.Map<TMappedEntity>(await GetByIdAsync(id));
        }
    }
}
