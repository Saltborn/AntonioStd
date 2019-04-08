using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections.Test;

namespace AntonioStd.Collections.Map.Tests
{
    [TestClass()]
    public abstract class AbstractMapTests
    {
        [TestMethod()]
        public void ClearTest()
        {
            var map = CreateMap()
                .Put("one", 1)
                .Put("two", 2)
                .Put("three", 3)
                .Put("four", 4)
                .Put("five", 5);

            Assert.AreEqual(5, map.Count);

            map.Clear();

            Assert.AreEqual(0, map.Count);
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            var map = CreateMap()
               .Put("one", 1)
               .Put("two", 2)
               .Put("three", 3)
               .Put("four", 4)
               .Put("five", 5);

            bool actual = map.ContainsKey("three");

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ContainsValueTest()
        {
            var map = CreateMap()
               .Put("one", 1)
               .Put("two", 2)
               .Put("three", 3)
               .Put("four", 4)
               .Put("five", 5);

            bool actual = map.ContainsValue(4);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GetTest()
        {
            var map = CreateMap()
               .Put("one", 1)
               .Put("two", 2)
               .Put("three", 3)
               .Put("four", 4)
               .Put("five", 5);

            int actual = map.Get("four");

            Assert.AreEqual(4, actual);
        }

        [TestMethod()]
        public void GetIteratorTest()
        {
            var map = CreateMap()
             .Put("one", 1)
             .Put("two", 2)
             .Put("three", 3)
             .Put("four", 4)
             .Put("five", 5);

            var iterator = map.GetIterator();

            while (iterator.HasNext())
            {
                (var key, var value) = iterator.Next();

                Assert.AreEqual(map.Get(key) , value);
            }
        }

        [TestMethod()]
        public void PutTest()
        {
            var map = CreateMap()
             .Put("one", 1)
             .Put("two", 2)
             .Put("three", 3)
             .Put("four", 4)
             .Put("five", 5);

            map.Put("six", 6);

            Assert.AreEqual(6, map.Count);
        }

        protected abstract IMutableMap<string, int> CreateMap();
    }
}