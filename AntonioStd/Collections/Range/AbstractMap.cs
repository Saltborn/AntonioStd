using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections.Range
{
    public abstract class AbstractMap<K,T> : AbstractCollection<Tuple<K,T>> , IMap<K,T>
    {
        public override int Count { get ; protected set ; }

        public virtual bool ContainsKey(K key)
        {
            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                if (Equals(iterator.Next().Item1, key))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual bool ContainsValue(T value)
        {
            var iterator = GetIterator();

            while (iterator.HasNext())
            {
                if (Equals(iterator.Next().Item2, value))
                {
                    return true;
                }
            }

            return false;
        }

        public abstract T Get(K key);
    }
}
