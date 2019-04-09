using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections.Test;

namespace AntonioStd.Collections.List.Tests
{
    [TestClass()]
    public class LinkedListQueueTests : AbstractCollectionTest<IQueue<int>>
    {

        [TestMethod()]
        public void DequeueTest()
        {
            IQueue<int> testInstance = CrateTestInstance();

            var actual = testInstance.Dequeue();

            Assert.AreEqual(0, actual);
            Assert.AreEqual(5, testInstance.Count);
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            IQueue<int> testInstance = CrateTestInstance();

            var actual = testInstance.Enqueue(6);

            Assert.AreEqual(7, actual.Count);
        }

        [TestMethod()]
        public void PeekTest()
        {
            IQueue<int> testInstance = CrateTestInstance();

            var actual = testInstance.Peek();

            Assert.AreEqual(actual, 0);
        }

        public override IQueue<int> CrateEmptyTestInstance()
        {
            return new LinkedListQueue<int>();
        }

        public override IQueue<int> CrateTestInstance()
        {
            return new LinkedListQueue<int>().Enqueue(0)
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3)
                .Enqueue(4)
                .Enqueue(5);
        }
    }
}