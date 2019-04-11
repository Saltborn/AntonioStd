using System;
using AntonioStd.Collections;
using AntonioStdTests.Collections.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.Set
{
    [TestClass]
    public abstract class AbstractSetTests : AbstractCollectionTest<IMutableSet<int>>
    {
        [TestMethod]
        public void ExeptTest()
        {
            var testInstance = CreateSet().Add(0)
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4);

            var other = CreateSet().Add(0)
                .Add(1);

            var expected = CreateSet().Add(2)
                .Add(3)
                .Add(4);

           var actual = testInstance.Exept(other);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IntersectTest()
        {
            var testInstance = CreateSet().Add(0)
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4);

            var other = CreateSet().Add(4)
                .Add(5)
                .Add(6);

            var expected = CreateSet().Add(4);
                

            var actual = testInstance.Intersect(other);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnionTest()
        {
            var actual = CreateSet().Add(0)
                 .Add(1)
                 .Add(2)
                 .Add(3)
                 .Add(4);

            var other = CreateSet().Add(0)
                .Add(1);

            var expected = CreateSet().Add(0)
                 .Add(1)
                 .Add(2)
                 .Add(3)
                 .Add(4);

            actual.Union(other);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {
            var actual = CreateSet().Add(0)
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4)
                .Add(5);

            var expected = CreateSet().Add(0)
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4)
                .Add(5);

            Assert.AreEqual(expected, actual);
        }

        protected abstract IMutableSet<int> CreateSet();
    }
}
