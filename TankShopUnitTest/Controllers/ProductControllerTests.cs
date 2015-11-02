using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class ProductControllerTests : ControllerTestsBase
    {
        private ProductController Controller;
        private AdminProductsController AdminController;
        
        private readonly Product[] products = new Product[]
        {
            new Product
            {
                ProductId = 1
            },
            new Product
            {
                ProductId = 2
            }
        };

        private readonly Category[] categories = new Category[]
        {
            new Category
            {
                CategoryId = 1,
                Name = "Category"
            }
        };

        [TestInitialize]
        public new void Setup()
        {
            base.Setup();

            Services.Configure(new ProductServiceStub(products));
            Services.Configure(new CategoryServiceStub(categories));

            Controller = new ProductController(Services);
            AdminController = new AdminProductsController(Services);
        }

        //[TestMethod]
        //public void ProductControllerTest()
        //{
        //    Assert.Fail();
        //}
        
        [TestMethod]
        public void ProductNotFoundTest()
        {
            var nonexistentProductId = -1;

            var result = Controller.Product(nonexistentProductId, null);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
        
        [TestMethod]
        public void ProductTest()
        {
            var product = products[0];
            product.CategoryId = categories[0].CategoryId;

            var result = Controller.Product(product.ProductId, null)
                as ViewResult;

            Assert.IsNotNull(result.ViewBag.Product,
                "ViewBag should contain a Product.");
            Assert.IsInstanceOfType(result.ViewBag.Product, typeof(ProductView));
            Assert.AreEqual(result.ViewBag.Product.ProductId,
                product.ProductId,
                "Product not in ViewBag.Product.");
            Assert.IsNotNull(result.ViewBag.Product.Category,
                "Product should have a Category (loaded).");
            Assert.AreEqual(result.ViewBag.Product.Category.CategoryId,
                product.Category.CategoryId,
                "Product does not contain correct category.");
        }

        [TestCleanup]
        public new void Teardown()
        {
            AdminController.Dispose();
            AdminController = null;

            Controller.Dispose();
            Controller = null;

            base.Teardown();
        }

    }

    internal class CategoryServiceStub : ICategoryService
    {
        private Category[] categories;

        public CategoryServiceStub(Category[] categories)
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

        public void Delete(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object unmappedEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object entityId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll(ICollection<int> idList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMappedEntity> GetAll<TMappedEntity>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>()
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

        public TMappedEntity GetByIdMapped<TMappedEntity>(object entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMappedEntity> GetMapped<TMappedEntity>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> order = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Save()
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

    internal class ProductServiceStub : IProductService
    {
        private List<Product> products;

        public ProductServiceStub(Product[] products)
        {
            this.products = products.ToList();
        }

        public Product Create(Product entity)
        {
            products.Add(entity);

            return entity;
        }

        public Product Create(object unmappedEntity)
        {
            return Create(unmappedEntity as Product);
        }

        public Task<Product> CreateAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Create(unmappedEntity));
        }

        public void Delete(object unmappedEntity)
        {
            Delete(unmappedEntity as Product);
        }

        public void Delete(Product entity)
        {
            products.Remove(entity);
        }

        public Task DeleteAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Delete(unmappedEntity));
        }

        public void DeleteById(object entityId)
        {
            Delete(products.Where(p => ((int)entityId) == p.ProductId));
        }

        public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null, string includeProperties = "")
        {
            return products.Where(filter.Compile());
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public IEnumerable<Product> GetAll(ICollection<int> productIdList)
        {
            return Get(p => productIdList.Contains(p.ProductId));
        }

        public IEnumerable<TMappedEntity> GetAll<TMappedEntity>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.Factory.StartNew(() => GetAll());
        }

        public IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMappedEntity> GetAllMapped<TMappedEntity>(ICollection<int> productIdList)
        {
            throw new NotImplementedException();
        }

        public Product GetById(object entityId)
        {
            return GetById((int)entityId);
        }

        public Product GetById(int productId)
        {
            return Get(p => productId == p.ProductId).FirstOrDefault();
        }

        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            return Mapper.Map<TMappedEntity>(GetById(entityId));
        }

        public Task<Product> GetByIdAsync(object entityId)
        {
            return Task.Factory.StartNew(() => GetById(entityId));
        }

        public Task<TMappedEntity> GetByIdAsync<TMappedEntity>(int? id)
        {
            return Task.Factory.StartNew(() => Mapper.Map<TMappedEntity>(GetById(id)));
        }

        public TMappedEntity GetByIdMapped<TMappedEntity>(object entityId)
        {
            return Mapper.Map<TMappedEntity>(GetById(entityId));
        }

        public IEnumerable<TMappedEntity> GetMapped<TMappedEntity>(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null, string includeProperties = "")
        {
            return Mapper.Map<IEnumerable<TMappedEntity>>(Get(filter, order, includeProperties));
        }

        public IEnumerable<TMappedType> GetMappedProductsByCategoryId<TMappedType>(int productId)
        {
            return Mapper.Map<IEnumerable<TMappedType>>(GetProductsByCategoryId(productId));
        }

        public IEnumerable<Product> GetProductsByCategory(Category category)
        {
            return GetProductsByCategoryId(category.CategoryId);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return Get(product => categoryId == product.CategoryId);
        }

        public void Save()
        {
        }

        public Product Update(object unmappedEntity)
        {
            return unmappedEntity as Product;
        }

        public Product Update(Product entity)
        {
            return entity;
        }

        public Task<Product> UpdateAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Update(unmappedEntity));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductServiceStub() {
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