using AutoMapper;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    public class ProductService : EntityService<Product>, IProductService
    {
        public ProductService()
            : this(new TankshopDbContext())
        {

        }

        public ProductService(ITankshopDbContext context)
            : base(new ProductRepository(context))
        {

        }

        public ProductService(IProductRepository repository)
            : base(repository)
        {
        }
        
        public ICollection<Product> GetAll(ICollection<int> productIdList)
        {
            return Get(p => productIdList.Contains(p.Id));
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            return Get<TMappedEntity>(p => productIdList.Contains(p.Id));
        }

        public Product GetById(int productId)
        {
            return Repository.GetById(productId);
        }

        public ICollection<TMappedType> GetProductsByCategoryId<TMappedType>(int categoryId)
        {
            return Mapper.Map<ICollection<TMappedType>>(GetProductsByCategoryId(categoryId));
        }

        public ICollection<TMappedType> GetProductsByCategory<TMappedType>(Category category)
        {
            return Mapper.Map<ICollection<TMappedType>>(GetProductsByCategoryId(category.CategoryId));
        }

        public ICollection<Product> GetProductsByCategory(Category category)
        {
            return GetProductsByCategoryId(category.CategoryId);
        }

        public ICollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return Repository.Get(product => product.CategoryId == categoryId);
        }
        
        public async Task<TMappedEntity> GetByIdAsync<TMappedEntity>(int? id)
        {
            return Mapper.Map<TMappedEntity>(await GetByIdAsync(id));
        }
    }
}
