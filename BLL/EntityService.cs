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
            return Repository.Add(entity);
        }

        /***
         *  Creates the given entity in the underlying repository.
         */
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await Repository.AddAsync(entity);
        }

        /***
         *  Creates the given {unmappedEntity} as an instance of {TEntity}
         *  through AutoMapper in the underlying repository.
         */
        public TEntity Create(object unmappedEntity)
        {
            return Create(Mapper.Map<TEntity>(unmappedEntity));
        }

        /***
         *  Creates the given {unmappedEntity} as an instance of {TEntity}
         *  through AutoMapper in the underlying repository.
         */
        public async Task<TEntity> CreateAsync(object unmappedEntity)
        {
            return await CreateAsync(Mapper.Map<TEntity>(unmappedEntity));
        }

        #endregion Create
        #region Delete

        /***
         *  Deletes the given entity from the underlying repository.
         */
        public bool Remove(TEntity entity)
        {
            return Repository.Remove(entity);
        }

        /***
         *  Deletes the given entity from the underlying repository.
         */
        public async Task<bool> RemoveAsync(TEntity entity)
        {
            return await Repository.RemoveAsync(entity);
        }

        public bool Remove(object unmappedEntity)
        {
            return Remove(Mapper.Map<TEntity>(unmappedEntity));
        }

        public async Task<bool> RemoveAsync(object unmappedEntity)
        {
            return await RemoveAsync(Mapper.Map<TEntity>(unmappedEntity));
        }

        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  repository.
         */
        public bool RemoveById(object entityId)
        {
            return Repository.RemoveById(entityId);
        }

        /***
         *  Deletes the entity with the given {entityId} from the underlying
         *  repository.
         */
        public async Task<bool> DeleteByIdAsync(object entityId)
        {
            return await Repository.RemoveByIdAsync(entityId);
        }

        #endregion Delete
        #region Get

        /***
         *  Gets all entities from the database matching the given {filter},
         *  ordered with the given {order} and including the list of properties
         *  on the entity in the given comma-separated string.
         */
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            return Repository.Get(filter, order, includeProperties);
        }

        /***
         *  Gets all entities from the repository matching the given {filter},
         *  ordered with the given {order} and including the list of properties
         *  on the entity in the given comma-separated string.
         */
        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            return await Repository.GetAsync(filter, order, includeProperties);
        }

        /***
         *  Returns all the entities in the underlying repository.
         */
        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        /***
         *  Returns all the entities in the underlying repository.
         */
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        /***
         * Gets an entity with the given {entityId} from the backing
         * repository.
         */
        public TEntity GetById(object entityId)
        {
            return Repository.GetById(entityId);
        }

        /***
         * Gets an entity with the given {entityId} from the backing
         * repository.
         */
        public async Task<TEntity> GetByIdAsync(object entityId)
        {
            return await Repository.GetByIdAsync(entityId);
        }

        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            return GetByIdMapped<TMappedEntity>(entityId);
        }

        public TMappedEntity GetByIdMapped<TMappedEntity>(object entityId)
        {
            return Mapper.Map<TMappedEntity>(GetById(entityId));
        }

        public IEnumerable<TMappedEntity> GetAll<TMappedEntity>()
        {
            return GetAllMapped<TMappedEntity>();
        }

        public IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>()
        {
            return Mapper.Map<IEnumerable<TMappedEntity>>(GetAll());
        }

        public IEnumerable<TMappedEntity> GetMapped<TMappedEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            return Mapper.Map<IEnumerable<TMappedEntity>>(
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

        /***
         *  Saves the current Repository state.
         */
        public async Task SaveAsync()
        {
            await Repository.SaveAsync();
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
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Repository.UpdateAsync(entity);
        }

        /***
         *  Updates the property of the entity in the repository.
         */
        public TEntity Update(object unmappedEntity)
        {
            return Update(Mapper.Map<TEntity>(unmappedEntity));
        }

        /***
         *  Updates the property of the entity in the repository.
         */
        public async Task<TEntity> UpdateAsync(object unmappedEntity)
        {
            return await UpdateAsync(Mapper.Map<TEntity>(unmappedEntity));
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
                    Repository.Dispose();
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