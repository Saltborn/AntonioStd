using System;
using AntonioStd.Collections;
using AntonioStdTests.Collections.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.List.Test
{
    [TestClass]
    public abstract class AbstractMutableListTest : AbstractMutableCollectionTest<IMutableList<int>>
    {
        [TestMethod()]
        public void GivenArrayList_WhenGet_ThenTrueListElement()
        {
            var testInstance = CrateTestInstance();

            Assert.AreEqual(1, testInstance.Get(1));
        }

        [TestMethod()]
        public void GivenArrayList_WhenAdd_ThenAddElement()
        {
            var actual = CrateTestInstance();
            var expected = CrateExpectedInstance(0, 1, 2, 3, 4, 5, 6);

            actual.Add(6);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GivenArrayList_WhenSet_ThenTrueSetValue()
        {
            var actual = CrateTestInstance();
            var expected = CrateExpectedInstance(0, 8, 2, 3, 4, 5);

            actual.Set(1, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenInsert_ThenInsertElement()
        {
            var actual = CrateTestInstance();
            var expected = CrateExpectedInstance(0, 1, 6, 2, 3, 4, 5);

            actual.Insert(2, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenRemove_ThenRemoveElement()
        {
            var actual = CrateTestInstance();
            var expected = CrateExpectedInstance(0, 1, 3, 4, 5);

            actual.Remove(2);

            Assert.AreEqual(expected, actual);
        }

        public abstract IMutableList<int> CrateExpectedInstance(params int[] values);
    }
}
