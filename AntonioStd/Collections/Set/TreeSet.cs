using AntonioStd.Collections.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Set
{
    public class TreeSet<T> : AbstractSet<T>
    {
        private IComparer<T> comparer;

        public TreeSet(IComparer<T> comparer) : base( new TreeMap<T,object>(comparer))
        {
           this.comparer = comparer;
        }

        protected override IMutableSet<T> CreateSet()
        {
            return new TreeSet<T>(comparer);
        }
    }
}
