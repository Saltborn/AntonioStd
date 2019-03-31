using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections;
using AntonioStdTests.Collections.Test;

namespace AntonioStd.Collections.Range.Tests
{
    [TestClass()]
    public class RangeTests : AbstractCollectionTest<IRange>
    {
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

        public override IRange CrateTestInstance()
        {
            return Range.ClosedClosed(0, 5);
        }

        public override IRange CrateEmptyTestInstance()
        {
            return Range.ClosedClosed(0, 0);
        }
    }
}