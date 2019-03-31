using System;
using AntonioStd.Collections;
using AntonioStdTests.Collections.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.List.Test
{
    [TestClass]
    public abstract class AbstractImmutableListTest : AbstractCollectionTest<IList<int>>
    {
        [TestMethod()]
        public void GivenArrayList_WhenGet_ThenTrueListElement()
        {
            var testInstance = CrateEmptyTestInstance();

            Assert.AreEqual(2, testInstance.Get(1));
        }
    }
}
