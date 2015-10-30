using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    /***
     * For use with a mapper of some sort,
     * any implementing class should then perform
     * a mapping operation and then apply the
     * result to the corresponding IRepository call.
     * 
     * <see>Nettbutikk.BusinessLogic.IEntityService</see>
     */
    public interface IMappedEntityService<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TMappedEntity> GetAll<TMappedEntity>();
        IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>();
        TMappedEntity GetById<TMappedEntity>(object entityId);
        TMappedEntity GetByIdMapped<TMappedEntity>(object entityId);

        /***
         *  Fetches entities from the underlying repository that match the
         *  given filter (if any), in the given order (if any), and includes
         *  the given comma-separated list of related entities (if any).
         */
        IEnumerable<TMappedEntity> GetMapped<TMappedEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "");

        TEntity Create(object unmappedEntity);
        Task<TEntity> CreateAsync(object unmappedEntity);
        void Delete(object unmappedEntity);
        Task DeleteAsync(object unmappedEntity);
        TEntity Update(object unmappedEntity);
        Task<TEntity> UpdateAsync(object unmappedEntity);
    }
}