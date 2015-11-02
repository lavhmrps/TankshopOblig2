using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  Defines a service for a generic entity.
     *  The base idea is for this interface to at the very least
     *  mirror that of the repository, and
     */
    public interface IEntityService<TEntity> : IDisposable, IService
        where TEntity : class, new()
    {
        /***
         *  Creates an entity in the underlying repository.
         */
        TEntity Create(TEntity entity);

        /***
         *  Deletes the given entity from the underlying repository.
         */
        bool Remove(TEntity entity);

        /***
         *  Deletes an entity, with the given {entityId} from the underlying repository.
         */
        bool RemoveById(object entityId);

        /***
         *  Fetches entities from the underlying repository that match the
         *  given filter (if any), in the given order (if any), and includes
         *  the given comma-separated list of related entities (if any).
         */
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "");

        /***
         *  Fetches all entities in the underlying repository.
         */
        IEnumerable<TEntity> GetAll();

        /***
         *  Fetches all entities in the underlying repository.
         */
        Task<IEnumerable<TEntity>> GetAllAsync();

        /***
         *  Gets an entity with matching {entityId} from the underlying repository.
         */
        TEntity GetById(object entityId);

        /***
         *  Gets an entity with matching {entityId} from the underlying repository.
         */
        Task<TEntity> GetByIdAsync(object entityId);

        /***
         *  Asks the backing repository to save/commit its state to disk.
         */
        void SaveChanges();

        /***
         *  Updates the repository with the given {entity},
         *  marking it modified/dirty.
         */
        TEntity Update(TEntity entity);
    }
}