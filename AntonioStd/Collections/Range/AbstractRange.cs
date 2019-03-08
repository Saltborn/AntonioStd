using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public abstract class AbstractRange : IRange
    {
        public int Start { get; }

        public int End { get; }

        protected internal AbstractRange(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool Contains(int value)
        {
            return value >= Start && value <= End;
        }

        public int Count()
        {
            return End - Start + 1;
        }

        public IIterator<int> GetIterator()
        {
            return new RangeIterator(Start, End);
        }

        public int[] ToArray()
        {
            int[] array = new int[Count()];
            IIterator<int> iterator = this.GetIterator();
            int counter = 0;

            while (iterator.HasNext())
            {
                array[counter] = iterator.Next();
                counter++;
            }

            return array;
        }

        public override bool Equals(object obj)
        {
            var range = obj as ClosedClosedRange;
            return range != null &&
                   Start == range.Start &&
                   End == range.End;
        }

        public override int GetHashCode()
        {
            var hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + End.GetHashCode();
            return hashCode;
        }

        private class RangeIterator : IIterator<int>
        {
            private int currentElement;
            private int lastElement;

            public RangeIterator(int currentElement, int lastElement)
            {
                this.currentElement = currentElement;
                this.lastElement = lastElement;
            }

            public bool HasNext()
            {
                return currentElement <= lastElement;
            }

            public int Next()
            {
                return currentElement++;
            }
        }
    }
}
