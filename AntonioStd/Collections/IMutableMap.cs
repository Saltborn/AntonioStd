using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IMutableMap<K, T> : IMap<K, T>, IMutableCollection<T>
    {
        IMutableMap<K, T> Put(K key, T value);
    }
}
