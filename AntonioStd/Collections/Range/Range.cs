using AntonioStd.Collections.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class Range : AbstractCollection<int>, IRange
    {
        public int Start { get; }

        public int End { get; }

        public override int Count
        {
            get
            {
                return End + 1 - Start;
            }
            protected set { }
        }

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

        public override bool Contains(int value)
        {
            return value >= Start && value <= End;
        }

        public override IIterator<int> GetIterator()
        {
            return new RangeIterator(Start, End);
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
