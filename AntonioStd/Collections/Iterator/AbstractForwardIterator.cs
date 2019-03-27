using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Iterator
{
    public abstract class AbstractForwardIterator<T> : AbstarctIterator<T>
    {
        protected AbstractForwardIterator() : base(0)
        {
        }

        public override T Next()
        {
           var value = InternalNext();

            Index++;

            return value;
        }

        protected abstract T InternalNext();
    }
}
