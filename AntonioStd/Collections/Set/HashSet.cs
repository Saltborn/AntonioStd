using AntonioStd.Collections.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Set
{
    public class HashSet<T> : AbstractSet<T>
    {
        private int expectedcount;

        public HashSet(int expectedcount) : base(new HashTable<T, object>(expectedcount))
        {
            this.expectedcount = expectedcount;
        }

        protected override IMutableSet<T> CreateSet()
        {
            return new HashSet<T>(expectedcount);
        }

    }
}
