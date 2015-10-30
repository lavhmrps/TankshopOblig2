using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.DataAccess
{
    public interface IRepository<TEntity>
        : IBasicRepository<TEntity>, IAsyncRepository<TEntity>, IDisposable
        where TEntity : class, new()
    {

    }

    /***
     *  A repository for entities.
     */
    public interface IBasicRepository<TEntity>
        where TEntity : class, new()
    {
        /***
         *  Adds the given entity to the underlying data-store.
         */
        TEntity Create(TEntity entity);

        /***
         *  Deletes the entity from the underlying data-store (if it exists).
         */
        void Delete(TEntity entity);

        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  data-store (if it exists).
         */
        void DeleteById(object entityId);

        /***
         *  Gets a set of entities from the underlying data-store, {filter}ed
         *  and {order}ed, including properties in {includeProperties}.
         */
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "");

        /***
         *  Gets all the entities from the underlying data-store.
         */
        IEnumerable<TEntity> GetAll();

        /***
         *  Gets an entity with the given {entityId} from the underlying
         *  data-store.
         */
        TEntity GetById(object entityId);

        /***
         *  Updates the given entity with new data.
         */
        TEntity Update(TEntity entity);

        /***
         *  Flushes data to the underlying data-store.
         */
        void Save();
    }


    /***
     *  Implements the same interface as {IRepository}, but in an async manner.
     */
    public interface IAsyncRepository<TEntity>
        where TEntity : class, new()
    {
        /***
         *  Adds the given entity to the underlying data-store.
         */
        Task<TEntity> CreateAsync(TEntity entity);


        /***
         *  Deletes the entity from the underlying data-store (if it exists).
         */
        Task DeleteAsync(TEntity entity);

        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  data-store (if it exists).
         */
        Task DeleteByIdAsync(object entityId);


        /***
         *  Gets a set of entities from the underlying data-store, {filter}ed
         *  and {order}ed, including properties in {includeProperties}.
         */
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "");

        /***
         *  Gets all the entities from the underlying data-store.
         */
        Task<IEnumerable<TEntity>> GetAllAsync();

        /***
         *  Gets an entity with the given {entityId} from the underlying
         *  data-store.
         */
        Task<TEntity> GetByIdAsync(object entityId);


        /***
         *  Updates the given entity with new data.
         */
        Task<TEntity> UpdateAsync(TEntity entity);

        /***
         *  Flushes data to the underlying data-store.
         */
        Task SaveAsync();
    }
}