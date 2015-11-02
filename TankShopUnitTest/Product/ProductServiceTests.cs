using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                    ProductId = 1,
                    CategoryId = 1,
                    Category = firstCategory
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Category = firstCategory
                    },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    Category = secondCategory
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Category = secondCategory
                }
            };

            Repository = new EntityRepositoryStub<Product>(Collection);
            Service = new ProductService(Repository);
        }

        [TestMethod]
        public void GetMappedProductsByCategoryIdTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetMappedProductsByCategoryTest()
        {
            Assert.Inconclusive();
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
    }
}