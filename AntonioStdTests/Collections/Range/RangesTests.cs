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
    public class RangesTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenClosedClosed_ThenArgumentExeptionThrown()
        {
            Ranges.ClosedClosed(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenOpenClosed_ThenArgumentExeptionThrown()
        {
            Ranges.OpenClosed(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenClosedOpen_ThenArgumentExeptionThrown()
        {
            Ranges.ClosedOpen(5, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenRanges_WhenOpenOpen_ThenArgumentExeptionThrown()
        {
            Ranges.OpenOpen(5, 0);
        }
    }
}