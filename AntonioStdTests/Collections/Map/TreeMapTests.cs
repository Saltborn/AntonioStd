using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntonioStd.Collections.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioStdTests.Collections.Test;

namespace AntonioStd.Collections.Map.Tests
{
    [TestClass()]
    public class TreeMapTests : AbstractMapTests
    {
        protected override IMutableMap<string, int> CreateMap()
        {
            return new TreeMap<string, int>(StringComparer.InvariantCulture);
        }
    }
}