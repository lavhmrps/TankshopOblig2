using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nettbutikk.DataAccess;

namespace Nettbutikk.BusinessLogic.Tests
{
    [TestClass]
    public class ProductServiceTests : ServiceTestBase<Product>
    {
        [TestInitialize]
        public void Setup()
        {
            var firstCategory = new Category
            {
                CategoryId = 1
            };
            var secondCategory = new Category
            {
                CategoryId = 2
            };

            Collection = new List<Product> {
                new Product {
                    Id = 1,
                    CategoryId = 1,
                    Category = firstCategory
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Category = firstCategory
                    },
                new Product
                {
                    Id = 3,
                    CategoryId = 2,
                    Category = secondCategory
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Category = secondCategory
                }
            };

            Repository = new ProductRepositoryStub<Product>(Collection);
            Service = new ProductService(Repository as IProductRepository);
        }
        
        [TestMethod]
        public void GetProductsByCategoryTest()
        {
            var result = (Service as ProductService).GetProductsByCategory(new Category { CategoryId = 1 });
            CollectionAssert.IsSubsetOf(result as ICollection, Collection as ICollection);
            foreach (var e in Collection.Where(e => e.CategoryId != 1))
            {
                CollectionAssert.DoesNotContain(result as ICollection, e);
            }
        }

        [TestMethod]
        public void GetProductsByCategoryIdTest()
        {
            var result = (Service as ProductService).GetProductsByCategoryId(1);
            CollectionAssert.IsSubsetOf(result as ICollection, Collection as ICollection);
        }

        private class ProductRepositoryStub<T> : EntityRepositoryStub<Product>, IProductRepository
        {
            public ProductRepositoryStub(ICollection<Product> collection) : base(collection)
            {
            }
        }
    }
}