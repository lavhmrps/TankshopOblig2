using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
    public interface IMappedEntityService<TEntity> : IService
        where TEntity : class, new()
    {
        ICollection<TMappedEntity> GetAll<TMappedEntity>();
        TMappedEntity GetById<TMappedEntity>(object entityId);

        /***
         *  Fetches entities from the underlying repository that match the
         *  given filter (if any), in the given order (if any), and includes
         *  the given comma-separated list of related entities (if any).
         */
        ICollection<TMappedEntity> Get<TMappedEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "");

        bool Create(object unmappedEntity);
        bool Remove(object unmappedEntity);
        bool Update(object unmappedEntity);
    }
}