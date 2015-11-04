using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Nettbutikk.Controllers.Tests
{
    [TestClass]
    public class ProductControllerTests : ControllerTestsBase
    {
        private ProductController Controller;
        
        protected readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1
            },
            new Product
            {
                Id = 2
            }
        };

        protected readonly List<Category> Categories = new List<Category>
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

            Services.Inject(new ProductServiceStub(Products));
            Services.Inject(new CategoryServiceStub(Categories));

            Controller = new ProductController(Services);
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
            var product = Products[0];
            product.CategoryId = Categories[0].CategoryId;

            var result = Controller.Product(product.Id, null)
                as ViewResult;

            Assert.IsNotNull(result.ViewBag.Product,
                "ViewBag should contain a Product.");
            Assert.IsInstanceOfType(result.ViewBag.Product, typeof(ProductView));
            Assert.AreEqual(result.ViewBag.Product.ProductId,
                product.Id,
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

        public bool Create(Product entity)
        {
            products.Add(entity);
            return true;
        }

        public bool Create(object unmappedEntity)
        {
            return Create(unmappedEntity as Product);
        }
        
        public bool Remove(object unmappedEntity)
        {
            return Remove(unmappedEntity as Product);
        }

        public bool Remove(Product entity)
        {
            return products.Remove(entity);
        }
        
        public bool RemoveById(object entityId)
        {
            return Remove(products.Where(p => ((int)entityId) == p.Id).FirstOrDefault());
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
            return Get(p => productIdList.Contains(p.Id));
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>()
        {
            return Mapper.Map<ICollection<TMappedEntity>>(GetAll());
        }

        public ICollection<TMappedEntity> GetAll<TMappedEntity>(ICollection<int> productIdList)
        {
            throw new NotImplementedException();
        }
        
        public Product GetById(object entityId)
        {
            return GetById((int)entityId);
        }

        public Product GetById(int productId)
        {
            return Get(p => productId == p.Id).FirstOrDefault();
        }

        public TMappedEntity GetById<TMappedEntity>(object entityId)
        {
            return Mapper.Map<TMappedEntity>(GetById(entityId));
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

        public bool SaveChanges()
        {
            return true;
        }

        public bool Update(object unmappedEntity)
        {
            return true;
        }

        public bool Update(Product entity)
        {
            return true;
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