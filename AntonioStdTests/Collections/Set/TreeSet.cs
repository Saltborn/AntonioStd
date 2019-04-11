using System;
using System.Collections.Generic;
using AntonioStd.Collections;
using AntonioStd.Collections.Set;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStdTests.Collections.Set
{
    [TestClass]
    public class TreeSet : AbstractSetTests
    {
        public override IMutableSet<int> CrateEmptyTestInstance()
        {
            return CreateSet();
        }

        public override IMutableSet<int> CrateTestInstance()
        {
            return CreateSet().Add(0)
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4)
                .Add(5);
        }

        protected override IMutableSet<int> CreateSet()
        {
            return new TreeSet<int>(Comparer<int>.Default);
        }
    }
}
