using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
   public interface IMutableCollection<T> : ICollection<T>
    {
        void Add(T value);

        void Clear();

        void Remove(int index);
    }
}
