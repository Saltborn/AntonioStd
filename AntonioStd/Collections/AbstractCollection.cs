using AntonioStd.Collections.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public abstract class AbstractCollection<T> : AbstractIterable<T>, ICollection<T>
    {
        public abstract int Count { get; protected set; }

        public virtual bool Contains(T value)
        {
            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                if (value.Equals(iterator.Next()))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual T[] ToArray()
        {
            var iterator = GetIterator();
            T[] array = new T[Count];

            for (int i=0; i<array.Length; i++)
            {
                array[i] = iterator.Next();
            }

            return array;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[ ");

            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                stringBuilder.Append(iterator.Next());

                if (iterator.HasNext())
                {
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.Append(" ]").ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ICollection<T> other))
            {
                return false;
            }

            if (Count != other.Count)
            {
                return false;
            }

            var iterator = new ZippedIterator<T, T>(GetIterator(), other.GetIterator());

            while (iterator.HasNext())
            {
                (var first, var second) = iterator.Next();

                if (!first.Equals(second))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 17;

            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                hashCode = 31 * hashCode + iterator.Next().GetHashCode();
            }

            return hashCode;
        }
    }
}
