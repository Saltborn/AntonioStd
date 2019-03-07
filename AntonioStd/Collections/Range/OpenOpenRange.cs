using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public class OpenOpenRange : IRange, IEquatable<OpenOpenRange>
    {
        public int Start { get; }

        public int End { get; }

        public OpenOpenRange(int start, int end)
        {
            Start = start + 1;
            End = end - 1;
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
            return Equals(obj as OpenOpenRange);
        }

        public bool Equals(OpenOpenRange other)
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
    }
}
