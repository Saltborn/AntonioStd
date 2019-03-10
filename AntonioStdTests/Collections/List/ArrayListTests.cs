using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.List.Tests
{
    [TestClass()]
    public class ArrayListTests
    {

        [TestMethod()]
        public void GivenArrayList_WhenAdd_ThenAddElement()
        {
            ArrayList<int> actual = ArrayList<int>.Of(1, 2, 3, 4, 5 );
            ArrayList<int> expected = ArrayList<int>.Of(1, 2, 3, 4, 5, 6);

            actual.Add(6);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GivenArrayList_WhenClear_ThenClearArray()
        {
            ArrayList<int> actual = ArrayList<int>.Of(1, 2, 3, 4, 5);
            ArrayList<int> expected = ArrayList<int>.Of();

            actual.Clear();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenContains_ThenTrueReturned()
        {
            ArrayList<int> testInstance = ArrayList<int>.Of(1, 2, 3, 4, 5);

            Assert.IsTrue(testInstance.Contains(3));
        }

        [TestMethod()]
        public void GivenArrayList_WhenCount_ThenTrueReturned()
        {
            ArrayList<int> testInstance = ArrayList<int>.Of(1, 2, 3, 4, 5);

            Assert.IsTrue(testInstance.Contains(5));
        }

        [TestMethod()]
        public void GivenArrayList_WhenGet_ThenTrueListElement()
        {
            ArrayList<int> testInstance = ArrayList<int>.Of(1, 2, 3, 4, 5);

            Assert.AreEqual(2, testInstance.Get(2));
        }

        [TestMethod()]
        public void GivenArrayList_WhenSet_ThenTrueSetValue()
        {
            ArrayList<int> actual = ArrayList<int>.Of(1, 2, 3, 4, 5);
            ArrayList<int> expected = ArrayList<int>.Of(1, 8, 3, 4, 5);

            actual.Set(2, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenGetItaror_ThenTrueListIsIterated()
        {
            ArrayList<int> testInstance = ArrayList<int>.Of(1, 2, 3, 4, 5);

            IIterator<int> iterator = testInstance.GetIterator();

            int counter = 0;

            while (iterator.HasNext())
            {
                int currentElement = iterator.Next();

                Assert.AreEqual(counter++, currentElement);
            }
        }

        [TestMethod()]
        public void GivenArrayList_WhenInsert_ThenInsertElement()
        {
            ArrayList<int> actual = ArrayList<int>.Of(1, 2, 3, 4, 5);
            ArrayList<int> expected = ArrayList<int>.Of(1, 2, 6, 3, 4, 5);

            actual.Insert(3, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenRemove_ThenRemoveElement()
        {
            ArrayList<int> actual = ArrayList<int>.Of(1, 2, 3, 4, 5);
            ArrayList<int> expected = ArrayList<int>.Of(1, 2, 4, 5);

            actual.Remove(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenArrayList_WhenToArray_ThenListIsArrayed()
        {
            ArrayList<int> testInstance = ArrayList<int>.Of(1, 2, 3, 4, 5);
            int[] expected = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, testInstance.ToArray());
        }
    }
}