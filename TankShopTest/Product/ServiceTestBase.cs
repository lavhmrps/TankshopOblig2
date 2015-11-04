using Nettbutikk.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nettbutikk.BusinessLogic.Tests
{
    public abstract class ServiceTestBase<TEntity>
        where TEntity : class, new()
    {
        private IRepository<TEntity> repository;

        protected EntityService<TEntity> Service { get; set; }
        protected EntityRepository<TEntity> Repository { get; set; }

        protected ICollection<TEntity> Collection { get; set; }
    }

    public class EntityRepositoryStub<TEntity> : EntityRepository<TEntity>
        where TEntity : class, new()
    {
        private ICollection<TEntity> Repository;

        public readonly Func<TEntity, object> DefaultIdGetterPredicate = (e) => e;
        private Func<TEntity, object> idPredicate;

        public Func<TEntity, object> IdGetterPredicate
        {
            get { return idPredicate ?? DefaultIdGetterPredicate; }
            set { idPredicate = value; }
        }

        public EntityRepositoryStub(ICollection<TEntity> repository)
            : base(null)
        {
            Repository = repository;
        }

        public EntityRepositoryStub(ICollection<TEntity> collection, Func<TEntity, object> idGetter)
            : this(collection)
        {
            IdGetterPredicate = idGetter;
        }

        public override TEntity Add(TEntity entity)
        {
            Repository.Add(entity);
            return entity;
        }

        public override Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Add(entity));
        }

        public override void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }

        public override Task RemoveAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Remove(entity));
        }

        public override void RemoveById(object entityId)
        {
            Repository
                .Where(e => IdGetterPredicate(e) == entityId)
                .Any(entity => Repository.Remove(entity));
        }

        public override Task RemoveByIdAsync(object entityId)
        {
            return Task.Factory.StartNew(() => RemoveById(entityId));
        }
        
        public override ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, string includeProperties = "")
        {
            return Repository.Where(filter.Compile()).ToList();
        }

        public override ICollection<TEntity> GetAll()
        {
            return Repository;
        }

        public override Task<ICollection<TEntity>> GetAllAsync()
        {
            return Task.Factory.StartNew(() => GetAll());
        }

        public override Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, string includeProperties = "")
        {
            return Task.Factory.StartNew(() => Get(filter, order, includeProperties));
        }

        public override TEntity GetById(object entityId)
        {
            return Repository.Where(e => IdGetterPredicate(e) == entityId).FirstOrDefault();
        }

        public override Task<TEntity> GetByIdAsync(object entityId)
        {
            return Task.Factory.StartNew(() => GetById(entityId));
        }

        public override void Save()
        {
        }

        public override Task SaveAsync()
        {
            return Task.Factory.StartNew(() => { });
        }

        public override TEntity Update(TEntity entity)
        {
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => entity);
        }
    }

    public class EntityServiceStub<TEntity> : EntityService<TEntity>
        where TEntity : class, new()
    {
        public EntityServiceStub(IRepository<TEntity> repository) : base(repository)
        {
        }
    }

}