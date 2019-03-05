using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IMap<K, T> : ICollection<Tuple<K, T>>
    {
        T Get(K key);

        bool ContainsKey(K key);

        bool ContainsValue(T value);
    }
}
