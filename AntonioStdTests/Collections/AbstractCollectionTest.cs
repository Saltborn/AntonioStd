using System;
using AntonioStd.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.Test
{
    [TestClass]
    public abstract class AbstractCollectionTest<T> where T : ICollection<int>
    {
        [TestMethod()]
        public void GivenCollection_WhenToArray_ThenRangeIsArrayed()
        {
            int[] actual = CrateTestInstance().ToArray();

            int[] expected = { 0, 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenCollection_WhenCount_ThenReturnCount()
        {
            int actual = CrateTestInstance().Count;

            Assert.AreEqual(6, actual);
        }

        [TestMethod()]
        public void GivenCollection_WhenGetIterator_ThenRangeIsIterated()
        {
            IIterator<int> iterator = CrateTestInstance().GetIterator();

            int counter = 0;

            while (iterator.HasNext())
            {
                int currentElement = iterator.Next();

                Assert.AreEqual(counter++, currentElement);
            }
        }

        [TestMethod()]
        public void GivenCollection_WhenForEach_ThenResult()
        {
            int counter = 0;

            CrateTestInstance().ForEach(i => Assert.AreEqual(counter++, i));
        }

        [TestMethod()]
        public void GivenMediumCollectionValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(CrateTestInstance().Contains(3));
        }

        [TestMethod()]
        public void GivenLowerBoundValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(CrateTestInstance().Contains(0));
        }

        [TestMethod()]
        public void GivenUpperBoundRangeValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(CrateTestInstance().Contains(5));
        }

        [TestMethod()]
        public void GivenLessThenLowerBoundValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(CrateTestInstance().Contains(-1));
        }

        [TestMethod()]
        public void GivenBiggerThenUpperBoundmRangeValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(CrateTestInstance().Contains(6));
        }

        public abstract T CrateTestInstance();

        public abstract T CrateEmptyTestInstance();
    }
}
