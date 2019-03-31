using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface IMutableList<T> : IList<T>, IMutableCollection<T>
    {
        void Insert(int index, T value);

        void Set(int index, T value);

        void Remove(int index);

        void Add(T value);
    }
}
