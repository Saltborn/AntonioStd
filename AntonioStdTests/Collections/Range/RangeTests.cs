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
    public class RangeTests
    {
        private IRange testInstance = Range.ClosedClosed(0, 5);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenClosedClosed_ThenArgumentExeptionThrown()
        {
            Range.ClosedClosed(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenOpenClosed_ThenArgumentExeptionThrown()
        {
            Range.OpenClosed(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenClosedOpen_ThenArgumentExeptionThrown()
        {
            Range.ClosedOpen(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenOpenOpen_ThenArgumentExeptionThrown()
        {
            Range.OpenOpen(5, 0);
        }

        [TestMethod()]
        public void GivenMediumRangeValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(3));
        }

        [TestMethod()]
        public void GivenLowerBoundValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(0));
        }

        [TestMethod()]
        public void GivenUpperBoundRangeValue_WhenContains_ThenTrueReturned()
        {
            Assert.IsTrue(testInstance.Contains(5));
        }

        [TestMethod()]
        public void GivenLessThenLowerBoundValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(testInstance.Contains(-1));
        }

        [TestMethod()]
        public void GivenBiggerThenUpperBoundmRangeValue_WhenContains_ThenFalseReturned()
        {
            Assert.IsFalse(testInstance.Contains(6));
        }

        [TestMethod()]
        public void GivenClosedClosedRange_WhenCount_ThenReturnCount()
        {
            int actual = testInstance.Count();

            Assert.AreEqual(6, actual);
        }

        [TestMethod()]
        public void GivenClosedCloseRange_WhenGetIterator_ThenRangeIsIterated()
        {
            IIterator<int> iterator = testInstance.GetIterator();

            int counter = 0;

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

            int[] expected = { 0, 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}