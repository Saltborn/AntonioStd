using System;
using AntonioStd.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntonioStd.Collections.Map.Tests
{
    [TestClass]
    public class HashTableTests : AbstractMapTests
    {
        protected override IMutableMap<string, int> CreateMap()
        {
            return new HashTable<string, int>(10);
        }
    }
}
