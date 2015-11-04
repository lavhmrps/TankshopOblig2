using AutoMapper;
using Nettbutikk.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  Base class for entity business logic.
     *  Implements common CRUD data readers and writers.
     */
    public abstract class EntityService<TEntity> :
        IEntityService<TEntity>, IMappedEntityService<TEntity>
        where TEntity : class, new()
    {
        /***
         *  The main repository of entities this service targets.
         */
        protected IRepository<TEntity> Repository { get; private set; }

        private EntityService()
        {

        }

        /***
         * Constructs a service targeting the given repository.
         */
        public EntityService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        #region Create

        /***
         *  Creates the given entity in the underlying repository.
         */
        public TEntity Create(TEntity entity)
        {
            try {
                return Repository.Add(entity);
            }
            catch(Exception e)
            {

            }

            return null;
        }
        
        /***
         *  Creates the given {unmappedEntity} as an instance of {TEntity}
         *  through AutoMapper in the underlying repository.
         */
        public TEntity Create(object unmappedEntity)
        {
            return Create(Mapper.Map<TEntity>(unmappedEntity));
        }
        
        #endregion Create
        #region Remove

        /***
         *  Deletes the given entity from the underlying repository.
         */
        public bool Remove(TEntity entity)
        {
            try {
                Repository.Remove(entity);
                Repository.Save();

                return true;
            }
            catch (Exception e)
            {

            }
            //If we get here, something went wrong, so return false
            return false;
        }
        
        public bool Remove(object unmappedEntity)
        {
            return Remove(Mapper.Map<TEntity>(unmappedEntity));
        }
        
        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  repository.
         */
        public bool RemoveById(object entityId)
        {
            try
            {
                Repository.RemoveById(entityId);
                Repository.Save();

                return true;
            }
            catch(Exception e)
            {

            }

            return false;
        }
        
        #endregion Remove
        #region Get

        /***
         *  Gets all entities from the database matching the given {filter},
         *  ordered with the given {order} and including the list of properties
         *  on the entity in the given comma-separated string.
         */
        public ICollection<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            return Repository.Get(filter, order, includeProperties);
        }
        
        /***
         *  Returns all the entities in the underlying repository.
         */
        public ICollection<TEntity> GetAll()
        {
            return Repository.GetAll();
        }
        
        /***
         * Gets an entity with the given {entityId} from the backing
         * repository.
         */
        public TEntity GetById(object entityId)
        {
            return Repository.GetById(entityId);
        }
        
        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            return GetById<TMappedEntity>(entityId);
        }
        
        public ICollection<TMappedEntity> GetAll<TMappedEntity>()
        {
            return Mapper.Map<ICollection<TMappedEntity>>(GetAll());
        }

        public ICollection<TMappedEntity> Get<TMappedEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            return Mapper.Map<ICollection<TMappedEntity>>(
                Get(filter, order, includeProperties));
        }

        #endregion Get

        #region Save

        /***
         *  Saves the current Repository state.
         */
        public void SaveChanges()
        {
            Repository.Save();
        }
        
        #endregion Save
        #region Update

        /***
         *  Updates the property of the entity in the repository.
         */
        public TEntity Update(TEntity entity)
        {
            return Repository.Update(entity);
        }
        
        /***
         *  Updates the property of the entity in the repository.
         */
        public TEntity Update(object unmappedEntity)
        {
            return Update(Mapper.Map<TEntity>(unmappedEntity));
        }

        #endregion Update

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Repository?.Dispose();
                    Repository = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EntityService() {
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