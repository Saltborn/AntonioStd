using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Iterator
{
    public abstract class AbstarctIterator<T> : IIterator<T>
    {
        public int Index { get; protected set; }

        protected AbstarctIterator(int index)
        {
            Index = index;
        }

        public abstract bool HasNext();

        public abstract T Next();       
    }
}
