using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.DataAccess
{
    public interface IProductRepository
    {
        Product Create(Product entity);
        Task<Product> CreateAsync(Product entity);

        void Delete(Product entity);
        Task DeleteAsync(Product entity);

        void DeleteById(object entityId);
        Task DeleteByIdAsync(object entityId);

        IEnumerable<Product> Get(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null,
            string includeProperties = "");
        Task<IEnumerable<Product>> GetAsync(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null,
            string includeProperties = "");

        IEnumerable<Product> GetAll();
        Task<IEnumerable<Product>> GetAllAsync();

        Product GetById(object entityId);
        Task<Product> GetByIdAsync(object entityId);

        void Save();
        Task SaveAsync();

        Product Update(Product entity);
        Task<Product> UpdateAsync(Product entity);
    }
}
