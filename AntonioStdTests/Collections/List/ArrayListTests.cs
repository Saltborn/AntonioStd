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
    public class ArrayListTests : AbstractMutableListTest
    {
        public override IMutableList<int> CrateEmptyTestInstance()
        {
            return ArrayList<int>.Of();
        }

        public override IMutableList<int> CrateExpectedInstance(params int[] values)
        {
            return ArrayList<int>.Of(values);
        }

        public override IMutableList<int> CrateTestInstance()
        {
            return ArrayList<int>.Of(0, 1, 2, 3, 4, 5);
        }
    }
}