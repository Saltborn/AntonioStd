using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range.Tests
{
    [TestClass()]
    public class OpenOpenRangeTests
    {
        private IRange testInstance = Ranges.OpenOpen(0, 5);

        [TestMethod()]
        public void GivenMediumRangeValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(3));
        }

        [TestMethod()]
        public void GivenLowerBoundValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(1));
        }

        [TestMethod()]
        public void GivenUpperBoundmRangeValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(4));
        }

        [TestMethod()]
        public void GivenLessThenLowerBoundValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(testInstance.Contains(0));
        }

        [TestMethod()]
        public void GivenBiggerThenUpperBoundmRangeValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(testInstance.Contains(5));
        }


        [TestMethod()]
        public void GivenClosedClosedRange_WhenCount_ThenReturnCount()
        {
            int actual = testInstance.Count();

            Assert.AreEqual(4, actual);
        }

        [TestMethod()]
        public void GivenClosedCloseRange_WhenGetIterator_ThenRangeIsIterated()
        {
            IIterator<int> iterator = testInstance.GetIterator();

            int counter = 1;

            while (iterator.HasNext())
            {
                int currentElement = iterator.Next();

                Assert.AreEqual(counter++, currentElement);
            }
        }

        [TestMethod()]
        public void GivenClosedClosedRange_WhenToArray_ThenRangeIsArrayed()
        {
            int[] actual = testInstance.ToArray();

            int[] expected = { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}