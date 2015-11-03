using System.Collections.Generic;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace Nettbutikk.Controllers.Tests
{

    internal class CategoryServiceStub : ICategoryService
    {
        private IList<Category> categories;

        public CategoryServiceStub(IList<Category> categories)
        {
            this.categories = categories;
        }

        public Category Create(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public Category Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> CreateAsync(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(object entityId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> Get(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetAll(ICollection<int> idList)
        {
            throw new NotImplementedException();
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TMappedEntity> GetAllMapped<TMappedEntity>()
        {
            throw new NotImplementedException();
        }

        public Category GetById(object entityId)
        {
            throw new NotImplementedException();
        }

        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(object entityId)
        {
            throw new NotImplementedException();
        }
        
        public ICollection<TMappedEntity> Get<TMappedEntity>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Category Update(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(object unmappedEntity)
        {
            throw new NotImplementedException();
        }
    }

}