using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections.List.Test;

namespace AntonioStd.Collections.List.Tests
{
    [TestClass()]
    public class LinkedListTests : AbstractMutableListTest
    {
        [TestMethod()]
        public void GivenLinkedList_WhenReverseGet_ThenTrueListElement()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);

            Assert.AreEqual(4, testInstance.Get(3));
        }

        public override IMutableList<int> CrateEmptyTestInstance()
        {
            return LinkedList<int>.Of();
        }

        public override IMutableList<int> CrateExpectedInstance(params int[] values)
        {
            return LinkedList<int>.Of(values);
        }

        public override IMutableList<int> CrateTestInstance()
        {
            return LinkedList<int>.Of(0, 1, 2, 3, 4, 5);
        }
    }
}