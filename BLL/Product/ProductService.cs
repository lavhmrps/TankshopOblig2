using AutoMapper;
using Nettbutikk.Model;
using Nettbutikk.DataAccess;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public class ProductService : EntityService<Product>, IProductService
    {
        public ProductService()
            : this(new TankshopDbContext())
        {

        }

        public ProductService(TankshopDbContext context)
            : base(new ProductRepository(context))
        {

        }

        public ProductService(IProductRepository repository)
            : base(repository)
        {
        }
        
        #region Getters

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
        
        #endregion Getters

        #region Remove

        /***
         *  Deletes the given entity from the underlying repository.
         */
        public bool Remove(Product entity)
        {
            Repository.Remove(entity);
            Repository.Save();
            LogRemoval(entity);
        }
        
        public bool Remove(object unmappedEntity)
        {
            return Remove(Mapper.Map<Product>(unmappedEntity));
        }
        
        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  repository.
         */
        public new bool RemoveById(object productId)
        {
            var product = GetById(productId);

            if (null == product)
                return false;

            return Remove(product);
        }
        
        #endregion Remove

        #region Helpers

        protected void LogRemoval<IChangedEntity>(IChangedEntity entity)
        {
            //TODO: Implement
        }

        protected void LogEntityChange<IChangedEntity>(IChangedEntity entity)
        {
            //TODO: Implement
        }

        #endregion Helpers

    }
}
