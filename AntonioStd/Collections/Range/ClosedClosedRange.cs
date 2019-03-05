using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class ClosedClosedRange : IRange
    {
        public int Start { get; }

        public int End { get; }

        public ClosedClosedRange(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool Contains(int value)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IIterator<int> GetIterator()
        {
            throw new NotImplementedException();
        }

        public int[] ToArray()
        {
            throw new NotImplementedException();
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

    }
}
