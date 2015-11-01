using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.DataAccess
{
    public abstract class EntityRepository<TEntity> :
        IRepository<TEntity>
        where TEntity : class, new()
    {
        #region Properties and members

        internal ITankshopDbContext Context { get; private set; }

        protected DbSet<TEntity> Entities
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        #endregion Properties and members

        #region Constructors

        private EntityRepository()
        {
            Context = new TankshopDbContext();
        }

        public EntityRepository(ITankshopDbContext context)
        {
            Context = context;
        }

        #endregion Constructors

        #region Getters

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            var query = Entities.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (order != null ? order(query) : query).ToList();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order = null,
            string includeProperties = "")
        {
            var query = Entities.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await (order != null ? order(query) : query).ToListAsync();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public async virtual Task<ICollection<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        #endregion Getters

        #region Create

        public virtual TEntity Create(TEntity entity)
        {
            return Entities.Add(entity);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await Task.Factory.StartNew(() => Entities.Add(entity));
        }

        #endregion Create

        #region Update

        public virtual TEntity Update(TEntity entity)
        {
            AttachEntity(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await AttachEntityAsync(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        #endregion Update

        #region Delete

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => Delete(entity));
        }

        public virtual void DeleteById(object entityId)
        {
            Delete(GetById(entityId));
        }

        public async Task DeleteByIdAsync(object entityId)
        {
            await Task.Factory.StartNew(() => DeleteById(entityId));
        }

        #endregion Delete

        #region Save

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        #endregion Save

        #region Helpers

        protected void AttachEntity(TEntity entity)
        {
            if (EntityState.Detached == Context.Entry(entity).State)
            {
                Entities.Attach(entity);
            }
        }

        protected async Task AttachEntityAsync(TEntity entity)
        {
            var entityProperties = await Task<DbEntityEntry<TEntity>>
                .Factory.StartNew(() => Context.Entry(entity));

            if (EntityState.Detached == Context.Entry(entity).State)
            {
                await Task.Factory.StartNew(() => Entities.Attach(entity));
            }
        }

        #endregion Helpers

        #region IDisposable Support
        // To detect redundant calls:
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }


                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}