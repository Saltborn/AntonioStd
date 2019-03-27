using AntonioStd.Collections.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class Range : IRange, IEquatable<Range>
    {
        public int Start { get; }

        public int End { get; }

        protected internal Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        public static IRange ClosedClosed(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new Range(start, end);
        }

        public static IRange OpenOpen(int start, int end)
        {
            int realStart = start + 1;
            int realEnd = end - 1;

            if (realStart > realEnd)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new Range(realStart, realEnd);
        }

        public static IRange ClosedOpen(int start, int end)
        {
            int realEnd = end - 1;

            if (start > realEnd)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new Range(start, realEnd);
        }

        public static IRange OpenClosed(int start, int end)
        {
            int realSrart = start + 1;

            if (realSrart > end)
            {
                throw new ArgumentException($"End should be less or equal to the Start. Current: start = $start, end = $end");
            }
            return new Range(realSrart, end);
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
            return Equals(obj as Range);
        }

        public bool Equals(Range other)
        {
            return other != null &&
                   Start == other.Start &&
                   End == other.End;
        }

        public override int GetHashCode()
        {
            var hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + End.GetHashCode();
            return hashCode;
        }

        private class RangeIterator : AbstractForwardIterator<int>
        {
            private int currentElement;
            private int lastElement;

            public RangeIterator(int currentElement, int lastElement)
            {
                this.currentElement = currentElement;
                this.lastElement = lastElement;
            }

            public override bool HasNext()
            {
                return currentElement <= lastElement;
            }

            protected override int InternalNext()
            {
                return currentElement++;
            }
        }
    }
}
