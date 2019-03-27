using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Iterator
{
    public class ZippedIterator<T, K> : AbstractForwardIterator<Tuple<T, K>>
    {
        private IIterator<T> firstIterator;
        private IIterator<K> secondIterator;

        public ZippedIterator(IIterator<T> firstIterator, IIterator<K> secondIterator)
        {
            this.firstIterator = firstIterator;
            this.secondIterator = secondIterator;
        }

        public override bool HasNext()
        {
            return firstIterator.HasNext() && secondIterator.HasNext();
        }

        protected override Tuple<T, K> InternalNext()
        {
            return new Tuple<T, K>(firstIterator.Next(), secondIterator.Next());
        }
    }
}
