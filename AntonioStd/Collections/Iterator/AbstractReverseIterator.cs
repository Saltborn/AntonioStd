using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Iterator
{
    public abstract class AbstractReverseIterator<T> : AbstarctIterator<T>
    {
        protected AbstractReverseIterator() : base(0)
        {
        }

        public override T Next()
        {
            Index--;

            return InternalNext();
        }

        protected abstract T InternalNext();
    }
}

