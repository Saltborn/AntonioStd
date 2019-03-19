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
    public class LinkedListTests
    {

        [TestMethod()]
        public void GivenLinkedList_WhenAdd_ThenAddElement()
        {
            LinkedList<int> actual = LinkedList<int>.Of(1, 2, 3, 4, 5);
            LinkedList<int> expected = LinkedList<int>.Of(1, 2, 3, 4, 5, 6);

            actual.Add(6);

            Assert.AreEqual(actual, expected);
        }


        [TestMethod()]
        public void GivenEmptyLinkedList_WhenAdd_ThenAddElement()
        {
            LinkedList<int> actual = LinkedList<int>.Of();
            LinkedList<int> expected = LinkedList<int>.Of(1);

            actual.Add(1);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GivenLinkedList_WhenClear_ThenClearArray()
        {
            LinkedList<int> actual = LinkedList<int>.Of(1, 2, 3, 4, 5);
            LinkedList<int> expected = LinkedList<int>.Of();

            actual.Clear();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenLinkedList_WhenContains_ThenTrueReturned()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);

            Assert.IsTrue(testInstance.Contains(3));
        }

        [TestMethod()]
        public void GivenLinkedList_WhenCount_ThenTrueReturned()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);

            Assert.IsTrue(testInstance.Contains(5));
        }

        [TestMethod()]
        public void GivenLinkedList_WhenGet_ThenTrueListElement()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);

            Assert.AreEqual(2, testInstance.Get(1));
        }

        [TestMethod()]
        public void GivenLinkedList_WhenSet_ThenTrueSetValue()
        {
            LinkedList<int> actual = LinkedList<int>.Of(1, 2, 3, 4, 5);
            LinkedList<int> expected = LinkedList<int>.Of(1, 8, 3, 4, 5);

            actual.Set(1, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenLinkedList_WhenGetItaror_ThenTrueListIsIterated()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);

            IIterator<int> iterator = testInstance.GetIterator();

            int counter = 1;

            while (iterator.HasNext())
            {
                int currentElement = iterator.Next();

                Assert.AreEqual(counter++, currentElement);
            }
        }

        [TestMethod()]
        public void GivenLinkedList_WhenInsert_ThenInsertElement()
        {
            LinkedList<int> actual = LinkedList<int>.Of(1, 2, 3, 4, 5);
            LinkedList<int> expected = LinkedList<int>.Of(1, 2, 6, 3, 4, 5);

            actual.Insert(2, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenLinkedList_WhenRemove_ThenRemoveElement()
        {
            LinkedList<int> actual = LinkedList<int>.Of(1, 2, 3, 4, 5);
            LinkedList<int> expected = LinkedList<int>.Of(1, 2, 4, 5);

            actual.Remove(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenLinkedList_WhenToArray_ThenListIsArrayed()
        {
            LinkedList<int> testInstance = LinkedList<int>.Of(1, 2, 3, 4, 5);
            int[] expected = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, testInstance.ToArray());
        }
    }
}