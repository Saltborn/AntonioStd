using System;
using AntonioStd.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.Test
{
    [TestClass]
    public abstract class AbstractMutableCollectionTest<T> : AbstractCollectionTest<T> where T : IMutableCollection<int>
    {
        [TestMethod()]
        public void GivenArrayList_WhenClear_ThenClearArray()
        {
            var actual = CrateTestInstance();
            var expected = CrateEmptyTestInstance();

            actual.Clear();

            Assert.AreEqual(expected, actual);
        }
    }
}
