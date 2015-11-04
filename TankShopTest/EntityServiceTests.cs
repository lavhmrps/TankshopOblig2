using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic.Tests
{
    [TestClass]
    public class EntityServiceTests : ServiceTestBase<TestObject>
    {
        [TestInitialize]
        public void Setup()
        {
            Collection = new List<TestObject>
            {
                new TestObject
                {
                    Id = "1"
                },
                new TestObject
                {
                    Id = "2"
                },
                new TestObject
                {
                    Id = "3"
                }
            };
            Repository = new EntityRepositoryStub<TestObject>(Collection, (t) => t.Id);
            Service = new EntityServiceStub<TestObject>(Repository);
        }

        [TestMethod]
        public void CreateTest()
        {
            var testObject = new TestObject();
            Service.Create(testObject);
            Assert.IsTrue(Collection.Contains(testObject));
        }
        
        [TestMethod]
        public void DeleteTest()
        {
            var removedObject = Collection.ElementAt(1);
            Service.Remove(removedObject);
            Assert.IsFalse(Collection.Contains(removedObject));
        }
        
        [TestMethod]
        public void DeleteByIdTest()
        {
            var removedObject = Collection.ElementAt(1);
            Service.RemoveById(removedObject.Id);
            Assert.IsFalse(Collection.Contains(removedObject));
        }
        
        [TestMethod]
        public void GetTest()
        {
            var result = Service.Get(e => e.Id as string == "1");
            Assert.IsTrue(result.Contains(Collection.ElementAt(0)));
        }

        [TestMethod]
        public void GetAllTest()
        {
            var result = Service.GetAll();
            Assert.IsTrue(result.Count() == 3);
            Assert.IsTrue(result.Intersect(Collection).Count() == 3);
        }
        
        [TestMethod]
        public void GetByIdTest()
        {
            var entity = Collection.ElementAt(0);
            Assert.AreEqual(Service.GetById(entity.Id).Id, entity.Id);
        }
        
        [TestMethod]
        public void GetByIdMappedTest()
        {
        }
        
        [TestMethod]
        public void GetAllMappedTest()
        {
        }

        [TestMethod]
        public void GetMappedTest()
        {
        }

        [TestMethod]
        public void SaveTest()
        {
        }
        
        [TestMethod]
        public void UpdateTest()
        {
        }
    }

    public class TestObject
    {
        public object Id { get; set; }
    }
}