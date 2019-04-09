using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections.Test;

namespace AntonioStd.Collections.Stack.Tests
{
    [TestClass()]
    public class StackTests : AbstractCollectionTest<IStack<int>>
    {
        public override IStack<int> CrateEmptyTestInstance()
        {
            return new Stack<int>();
        }

        public override IStack<int> CrateTestInstance()
        {
            return new Stack<int>().Push(0)
                .Push(1)
                .Push(2)
                .Push(3)
                .Push(4)
                .Push(5);
        }
    }
}