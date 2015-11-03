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
        
        private readonly List<Product> products = new List<Product>
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

        private readonly List<Category> categories = new List<Category>
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

            Services.Inject(new ProductServiceStub(products));
            Services.Inject(new CategoryServiceStub(categories));

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

    internal class ProductServiceStub : IProductService
    {
        private List<Product> products;

        public ProductServiceStub(List<Product> products)
        {
            this.products = products;
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

        public bool Remove(object unmappedEntity)
        {
            return Remove(unmappedEntity as Product);
        }

        public bool Remove(Product entity)
        {
            return products.Remove(entity);
        }

        public Task<bool> RemoveAsync(object unmappedEntity)
        {
            return Task.Factory.StartNew(() => Remove(unmappedEntity));
        }

        public bool RemoveById(object entityId)
        {
            return Remove(products.Where(p => ((int)entityId) == p.ProductId).FirstOrDefault());
        }

        public ICollection<Product> Get(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null, string includeProperties = "")
        {
            return products.Where(filter.Compile()).ToList();
        }

        public ICollection<Product> GetAll()
        {
            return products;
        }

        public ICollection<Product> GetAll(ICollection<int> productIdList)
        {
            return Get(p => productIdList.Contains(p.ProductId));
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>()
        {
            return Mapper.Map<ICollection<TMappedEntity>>(GetAll());
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAllAsync()
        {
            return Task.Factory.StartNew(() => GetAll());
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
        
        public ICollection<TMappedEntity> Get<TMappedEntity>(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> order = null, string includeProperties = "")
        {
            return Mapper.Map<ICollection<TMappedEntity>>(Get(filter, order, includeProperties));
        }

        public ICollection<TMappedType> GetProductsByCategoryId<TMappedType>(int productId)
        {
            return Mapper.Map<ICollection<TMappedType>>(GetProductsByCategoryId(productId));
        }

        public ICollection<Product> GetProductsByCategory(Category category)
        {
            return GetProductsByCategoryId(category.CategoryId);
        }

        public ICollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return Get(product => categoryId == product.CategoryId);
        }

        public void SaveChanges()
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