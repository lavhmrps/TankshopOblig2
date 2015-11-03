using System.Collections.Generic;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;

namespace Nettbutikk.Controllers.Tests
{

    internal class CategoryServiceStub : ICategoryService
    {
        private List<Category> products;

        public CategoryServiceStub(List<Category> products)
        {
            this.products = products;
        }

        public Category Create(Category entity)
        {
            products.Add(entity);

            return entity;
        }

        public Category Create(object unmappedEntity)
        {
            return Create(unmappedEntity as Category);
        }

        public Task<Category> CreateAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Create(unmappedEntity));
        }

        public bool Remove(object unmappedEntity)
        {
            return Remove(unmappedEntity as Category);
        }

        public bool Remove(Category entity)
        {
            return products.Remove(entity);
        }

        public Task<bool> RemoveAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Remove(unmappedEntity));
        }

        public bool RemoveById(object entityId)
        {
            return Remove(products.Where(p => ((int)entityId) == p.CategoryId).FirstOrDefault());
        }

        public ICollection<Category> Get(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            return products.Where(filter.Compile()).ToList();
        }

        public ICollection<Category> GetAll()
        {
            return products;
        }

        public ICollection<Category> GetAll(ICollection<int> productIdList)
        {
            return Get(p => productIdList.Contains(p.CategoryId));
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>()
        {
            return Mapper.Map<ICollection<TMappedEntity>>(GetAll());
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetAllAsync()
        {
            return Task.Factory.StartNew(() => GetAll());
        }

        public Category GetById(object entityId)
        {
            return GetById((int)entityId);
        }

        public Category GetById(int productId)
        {
            return Get(p => productId == p.CategoryId).FirstOrDefault();
        }

        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            return Mapper.Map<TMappedEntity>(GetById(entityId));
        }

        public Task<Category> GetByIdAsync(object entityId)
        {
            return Task.Factory.StartNew(() => GetById(entityId));
        }

        public Task<TMappedEntity> GetByIdAsync<TMappedEntity>(int? id)
        {
            return Task.Factory.StartNew(() => Mapper.Map<TMappedEntity>(GetById(id)));
        }

        public ICollection<TMappedEntity> Get<TMappedEntity>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            return Mapper.Map<ICollection<TMappedEntity>>(Get(filter, order, includeProperties));
        }

        public ICollection<TMappedType> GetProductsByCategoryId<TMappedType>(int productId)
        {
            return Mapper.Map<ICollection<TMappedType>>(GetProductsByCategoryId(productId));
        }

        public ICollection<Category> GetProductsByCategory(Category category)
        {
            return GetProductsByCategoryId(category.CategoryId);
        }

        public ICollection<Category> GetProductsByCategoryId(int categoryId)
        {
            return Get(product => categoryId == product.CategoryId);
        }

        public void SaveChanges()
        {
        }

        public Category Update(object unmappedEntity)
        {
            return unmappedEntity as Category;
        }

        public Category Update(Category entity)
        {
            return entity;
        }

        public Task<Category> UpdateAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Update(unmappedEntity));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductServiceStub() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}